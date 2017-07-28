//----------------------------------------------------------------------------
//  Copyright (C) 2004-2017 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Cvb;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.VideoSurveillance;
using FaceDetection;

namespace VideoSurveilance
{
   public partial class VideoSurveilance : Form
   {
      
      private static VideoCapture _cameraCapture;
      
      private static BackgroundSubtractor _fgDetector;
      private static Emgu.CV.Cvb.CvBlobDetector _blobDetector;
      private static Emgu.CV.Cvb.CvTracks _tracker;

      public VideoSurveilance()
      {
         InitializeComponent();
         Run();
      }

      void Run()
      {
         try
         {
            _cameraCapture = new VideoCapture(1);
        

         _fgDetector = new Emgu.CV.VideoSurveillance.BackgroundSubtractorMOG2();
         _blobDetector = new CvBlobDetector();
         _tracker = new CvTracks();

         Application.Idle += ProcessFrame;
      }
      catch (Exception e)
      {
       
      }
    }

     //private int counter = 0;

      void ProcessFrame(object sender, EventArgs e)
      {
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

        picture.Save("C:\\Images\\" + Guid.NewGuid().ToString() + ".bmp" , ImageFormat.Bmp);
      }

    imageBox1.Image = frame;
    }
   }
}