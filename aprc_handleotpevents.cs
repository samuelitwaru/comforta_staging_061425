using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprc_handleotpevents : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_handleotpevents().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_EventName = new string(' ',0)  ;
         string aP1_JsonIN = new string(' ',0)  ;
         string aP2_JsonOUT = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_EventName=((string)(args[0]));
         }
         else
         {
            aP0_EventName="";
         }
         if ( 1 < args.Length )
         {
            aP1_JsonIN=((string)(args[1]));
         }
         else
         {
            aP1_JsonIN="";
         }
         if ( 2 < args.Length )
         {
            aP2_JsonOUT=((string)(args[2]));
         }
         else
         {
            aP2_JsonOUT="";
         }
         execute(aP0_EventName, aP1_JsonIN, out aP2_JsonOUT);
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public aprc_handleotpevents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_handleotpevents( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_EventName ,
                           string aP1_JsonIN ,
                           out string aP2_JsonOUT )
      {
         this.AV9EventName = aP0_EventName;
         this.AV15JsonIN = aP1_JsonIN;
         this.AV16JsonOUT = "" ;
         initialize();
         ExecuteImpl();
         aP2_JsonOUT=this.AV16JsonOUT;
      }

      public string executeUdp( string aP0_EventName ,
                                string aP1_JsonIN )
      {
         execute(aP0_EventName, aP1_JsonIN, out aP2_JsonOUT);
         return AV16JsonOUT ;
      }

      public void executeSubmit( string aP0_EventName ,
                                 string aP1_JsonIN ,
                                 out string aP2_JsonOUT )
      {
         this.AV9EventName = aP0_EventName;
         this.AV15JsonIN = aP1_JsonIN;
         this.AV16JsonOUT = "" ;
         SubmitImpl();
         aP2_JsonOUT=this.AV16JsonOUT;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV9EventName, "user-otp-validateuser") == 0 )
         {
            AV12GAMOTPEventSubscription.fromjsonstring( AV15JsonIN);
         }
         else if ( StringUtil.StrCmp(AV9EventName, "user-otp-generatecode") == 0 )
         {
            AV12GAMOTPEventSubscription.fromjsonstring( AV15JsonIN);
         }
         else if ( StringUtil.StrCmp(AV9EventName, "user-otp-sendcode") == 0 )
         {
            AV12GAMOTPEventSubscription.fromjsonstring( AV15JsonIN);
            AV13GAMUser.load( AV12GAMOTPEventSubscription.gxTpr_Userguid);
            AV13GAMUser.gxTpr_Postcode = AV12GAMOTPEventSubscription.gxTpr_Otpcode;
            AV13GAMUser.save();
         }
         else if ( StringUtil.StrCmp(AV9EventName, "user-otp-validatecode") == 0 )
         {
            AV12GAMOTPEventSubscription.fromjsonstring( AV15JsonIN);
         }
         else
         {
            AV12GAMOTPEventSubscription.fromjsonstring( AV15JsonIN);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV16JsonOUT = "";
         AV12GAMOTPEventSubscription = new GeneXus.Programs.genexussecurity.SdtGAMOTPEventSubscription(context);
         AV13GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         /* GeneXus formulas. */
      }

      private string AV15JsonIN ;
      private string AV16JsonOUT ;
      private string AV9EventName ;
      private GeneXus.Programs.genexussecurity.SdtGAMOTPEventSubscription AV12GAMOTPEventSubscription ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV13GAMUser ;
      private string aP2_JsonOUT ;
   }

}
