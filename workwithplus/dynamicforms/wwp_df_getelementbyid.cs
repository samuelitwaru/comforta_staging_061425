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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_getelementbyid : GXProcedure
   {
      public wwp_df_getelementbyid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_getelementbyid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                           short aP1_WWPFormElementId ,
                           out GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element aP2_CurrentElement )
      {
         this.AV8WWPForm = aP0_WWPForm;
         this.AV10WWPFormElementId = aP1_WWPFormElementId;
         this.AV11CurrentElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context) ;
         initialize();
         ExecuteImpl();
         aP0_WWPForm=this.AV8WWPForm;
         aP2_CurrentElement=this.AV11CurrentElement;
      }

      public GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element executeUdp( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                                                                                        short aP1_WWPFormElementId )
      {
         execute(ref aP0_WWPForm, aP1_WWPFormElementId, out aP2_CurrentElement);
         return AV11CurrentElement ;
      }

      public void executeSubmit( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                                 short aP1_WWPFormElementId ,
                                 out GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element aP2_CurrentElement )
      {
         this.AV8WWPForm = aP0_WWPForm;
         this.AV10WWPFormElementId = aP1_WWPFormElementId;
         this.AV11CurrentElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context) ;
         SubmitImpl();
         aP0_WWPForm=this.AV8WWPForm;
         aP2_CurrentElement=this.AV11CurrentElement;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV8WWPForm.gxTpr_Element.Count )
         {
            AV9ElementAux = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV8WWPForm.gxTpr_Element.Item(AV12GXV1));
            if ( ( AV9ElementAux.gxTpr_Wwpformelementid == AV10WWPFormElementId ) && ( AV9ElementAux.gxTpr_Wwpformelementparentid >= 0 ) )
            {
               AV11CurrentElement = AV9ElementAux;
               if (true) break;
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
         AV11CurrentElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV9ElementAux = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         /* GeneXus formulas. */
      }

      private short AV10WWPFormElementId ;
      private int AV12GXV1 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV8WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV11CurrentElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV9ElementAux ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element aP2_CurrentElement ;
   }

}
