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
namespace GeneXus.Programs.wwpbaseobjects {
   public class awwp_synchandler : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new wwpbaseobjects.awwp_synchandler().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_GAMEvents = new string(' ',0)  ;
         string aP1_inJson = new string(' ',0)  ;
         string aP2_outJson = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_GAMEvents=((string)(args[0]));
         }
         else
         {
            aP0_GAMEvents="";
         }
         if ( 1 < args.Length )
         {
            aP1_inJson=((string)(args[1]));
         }
         else
         {
            aP1_inJson="";
         }
         if ( 2 < args.Length )
         {
            aP2_outJson=((string)(args[2]));
         }
         else
         {
            aP2_outJson="";
         }
         execute(aP0_GAMEvents, aP1_inJson, out aP2_outJson);
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

      public awwp_synchandler( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awwp_synchandler( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_GAMEvents ,
                           string aP1_inJson ,
                           out string aP2_outJson )
      {
         this.AV8GAMEvents = aP0_GAMEvents;
         this.AV13inJson = aP1_inJson;
         this.AV15outJson = "" ;
         initialize();
         ExecuteImpl();
         aP2_outJson=this.AV15outJson;
      }

      public string executeUdp( string aP0_GAMEvents ,
                                string aP1_inJson )
      {
         execute(aP0_GAMEvents, aP1_inJson, out aP2_outJson);
         return AV15outJson ;
      }

      public void executeSubmit( string aP0_GAMEvents ,
                                 string aP1_inJson ,
                                 out string aP2_outJson )
      {
         this.AV8GAMEvents = aP0_GAMEvents;
         this.AV13inJson = aP1_inJson;
         this.AV15outJson = "" ;
         SubmitImpl();
         aP2_outJson=this.AV15outJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new WorkWithPlus.workwithplus_webgam.wwp_executesynchandler(context ).execute(  AV8GAMEvents,  AV13inJson, out  AV15outJson) ;
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
         AV15outJson = "";
         /* GeneXus formulas. */
      }

      private string AV8GAMEvents ;
      private string AV13inJson ;
      private string AV15outJson ;
      private string aP2_outJson ;
   }

}
