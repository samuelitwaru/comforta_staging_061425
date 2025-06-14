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
   public class gam_buildappurl : GXProcedure
   {
      public gam_buildappurl( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gam_buildappurl( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_LinkURL ,
                           out string aP1_URL )
      {
         this.AV8LinkURL = aP0_LinkURL;
         this.AV9URL = "" ;
         initialize();
         ExecuteImpl();
         aP1_URL=this.AV9URL;
      }

      public string executeUdp( string aP0_LinkURL )
      {
         execute(aP0_LinkURL, out aP1_URL);
         return AV9URL ;
      }

      public void executeSubmit( string aP0_LinkURL ,
                                 out string aP1_URL )
      {
         this.AV8LinkURL = aP0_LinkURL;
         this.AV9URL = "" ;
         SubmitImpl();
         aP1_URL=this.AV9URL;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10LastChar = (short)(StringUtil.StringSearchRev( AV8LinkURL, "/", -1));
         if ( AV10LastChar > 0 )
         {
            AV9URL = StringUtil.Substring( AV8LinkURL, AV10LastChar+1, StringUtil.Len( AV8LinkURL));
         }
         else
         {
            AV9URL = StringUtil.Trim( AV8LinkURL);
         }
         AV11GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV9URL = AV11GAMApplication.gxTpr_Environment.gxTpr_Url + AV9URL;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11GAMApplication.gxTpr_Environment.gxTpr_Programextension)) )
         {
            if ( StringUtil.StringSearch( AV9URL, "."+AV11GAMApplication.gxTpr_Environment.gxTpr_Programextension, 1) == 0 )
            {
               AV9URL += "." + AV11GAMApplication.gxTpr_Environment.gxTpr_Programextension;
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11GAMApplication.gxTpr_Environment.gxTpr_Programpackage)) && ( StringUtil.StrCmp(AV11GAMApplication.gxTpr_Environment.gxTpr_Programpackage, "null") != 0 ) )
         {
            if ( StringUtil.StringSearch( AV9URL, AV11GAMApplication.gxTpr_Environment.gxTpr_Programpackage+".", 1) == 0 )
            {
               AV9URL = AV11GAMApplication.gxTpr_Environment.gxTpr_Programpackage + "." + AV9URL;
            }
         }
         if ( StringUtil.StringSearch( AV9URL, "?", 1) == 0 )
         {
            AV9URL += "?";
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
         AV9URL = "";
         AV11GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         /* GeneXus formulas. */
      }

      private short AV10LastChar ;
      private string AV8LinkURL ;
      private string AV9URL ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV11GAMApplication ;
      private string aP1_URL ;
   }

}
