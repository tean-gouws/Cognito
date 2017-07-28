using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Cvb;
using Emgu.CV.Structure;
using Emgu.CV.VideoSurveillance;
using FaceDetection;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System.Windows.Media.Imaging;

namespace FacePic
{
  class Program
  {

    private static VideoCapture _cameraCapture;

    private static BackgroundSubtractor _fgDetector;
    private static Emgu.CV.Cvb.CvBlobDetector _blobDetector;
    private static Emgu.CV.Cvb.CvTracks _tracker;

    private static readonly IFaceServiceClient faceServiceClient =
        new FaceServiceClient("36027385b39542fbaf8186bc562df3dc", "https://westcentralus.api.cognitive.microsoft.com/face/v1.0");

    static Face[] faces;                   // The list of detected faces.
    String[] faceDescriptions;      // The list of descriptions for the detected faces.
    double resizeFactor;

    static void Main(string[] args)
    {
      _cameraCapture = new VideoCapture(1);


      _fgDetector = new Emgu.CV.VideoSurveillance.BackgroundSubtractorMOG2();
      _blobDetector = new CvBlobDetector();
      _tracker = new CvTracks();


      Task.Run(() =>
        {
          DetectFaces();
        })
        .ContinueWith((p) =>
        {
          if (p != null && p.IsFaulted)
          {
            Console.WriteLine(p.Exception.InnerException.Message);
          }
        });

      Task.Run(() =>
        {
          IdentifyFaces();
        })
        .ContinueWith((p) =>
        {
          if (p != null && p.IsFaulted)
          {
            Console.WriteLine(p.Exception.InnerException.Message);
          }
        });

      Console.ReadKey();

    }

    private static void DetectFaces()
    {

      while (true)
      {
        System.Threading.Thread.Sleep(100);

        Mat frame = _cameraCapture.QueryFrame();

        long detectionTime;
        List<Rectangle> faces = new List<Rectangle>();
        List<Rectangle> eyes = new List<Rectangle>();

        DetectFace.Detect(
          frame, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
          faces, eyes,
          out detectionTime);

        foreach (Rectangle face in faces)
        {
          CvInvoke.Rectangle(frame, face, new Bgr(Color.Red).MCvScalar, 2);


          var picture = frame.Bitmap.Clone(face, PixelFormat.DontCare);

          picture.Save("C:\\Images\\" + Guid.NewGuid().ToString() + ".bmp", ImageFormat.Bmp);
          Console.WriteLine("Face Identified");
        }
      }
    }

    private static async void IdentifyFaces()
    {
      while (true)
      {
        DirectoryInfo di = new DirectoryInfo("C:\\Images");
        string firstFileName = di.GetFiles().Select(fi => fi.Name).FirstOrDefault();

        SendImage(di.ToString() + "\\" + firstFileName);

        Thread.Sleep(3000);
        File.Delete(di.ToString() + "\\" + firstFileName);
      }
    }

    private static async Task<Face[]> UploadAndDetectFaces(string imageFilePath)
    {
      // The list of Face attributes to return.
      IEnumerable<FaceAttributeType> faceAttributes =
          new FaceAttributeType[] { FaceAttributeType.Gender, FaceAttributeType.Age, FaceAttributeType.Smile, FaceAttributeType.Emotion, FaceAttributeType.Glasses, FaceAttributeType.Hair };

      // Call the Face API.
      try
      {
        using (Stream imageFileStream = File.OpenRead(imageFilePath))
        {
          Face[] faces = await faceServiceClient.DetectAsync(imageFileStream, returnFaceId: true, returnFaceLandmarks: false, returnFaceAttributes: faceAttributes);
          return faces;
        }
      }
      // Catch and display Face API errors.
      catch (FaceAPIException f)
      {
       Console.WriteLine(f.ErrorMessage, f.ErrorCode);
        return new Face[0];
      }
      // Catch and display all other errors.
      catch (Exception e)
      {
        Console.WriteLine(e.Message, "Error");
        return new Face[0];
      }
    }

    public static async void SendImage(string fileName)
    {
      faces = await UploadAndDetectFaces(fileName);
      if (faces.Length > 0)
      {
        Console.WriteLine("Face Identified");
       // var identified = await faceServiceClient.IdentifyAsync("1", faces.Select(x => x.FaceId).ToArray<Guid>());
      }
    }



  }
}