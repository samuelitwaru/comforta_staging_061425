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
   public class prc_geterrorstringfromcollection : GXProcedure
   {
      public prc_geterrorstringfromcollection( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_geterrorstringfromcollection( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrorCollection ,
                           out string aP1_ErrorString )
      {
         this.AV10GAMErrorCollection = aP0_GAMErrorCollection;
         this.AV9ErrorString = "" ;
         initialize();
         ExecuteImpl();
         aP1_ErrorString=this.AV9ErrorString;
      }

      public string executeUdp( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrorCollection )
      {
         execute(aP0_GAMErrorCollection, out aP1_ErrorString);
         return AV9ErrorString ;
      }

      public void executeSubmit( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP0_GAMErrorCollection ,
                                 out string aP1_ErrorString )
      {
         this.AV10GAMErrorCollection = aP0_GAMErrorCollection;
         this.AV9ErrorString = "" ;
         SubmitImpl();
         aP1_ErrorString=this.AV9ErrorString;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ErrorString = "";
         AV8count = 0;
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV10GAMErrorCollection.Count )
         {
            AV11GAMErrorItem = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV10GAMErrorCollection.Item(AV12GXV1));
            AV8count = (short)(AV8count+1);
            AV9ErrorString += AV11GAMErrorItem.gxTpr_Message;
            if ( AV8count < AV10GAMErrorCollection.Count )
            {
               AV9ErrorString += ", ";
            }
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV9ErrorString = "";
         AV11GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         /* GeneXus formulas. */
      }

      private short AV8count ;
      private int AV12GXV1 ;
      private string AV9ErrorString ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV11GAMErrorItem ;
      private string aP1_ErrorString ;
   }

}
