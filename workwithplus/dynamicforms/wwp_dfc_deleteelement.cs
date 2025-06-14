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
   public class wwp_dfc_deleteelement : GXProcedure
   {
      public wwp_dfc_deleteelement( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_dfc_deleteelement( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                           ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element aP1_CurrentElement )
      {
         this.AV11WWPForm = aP0_WWPForm;
         this.AV8CurrentElement = aP1_CurrentElement;
         initialize();
         ExecuteImpl();
         aP0_WWPForm=this.AV11WWPForm;
         aP1_CurrentElement=this.AV8CurrentElement;
      }

      public GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element executeUdp( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm )
      {
         execute(ref aP0_WWPForm, ref aP1_CurrentElement);
         return AV8CurrentElement ;
      }

      public void executeSubmit( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                                 ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element aP1_CurrentElement )
      {
         this.AV11WWPForm = aP0_WWPForm;
         this.AV8CurrentElement = aP1_CurrentElement;
         SubmitImpl();
         aP0_WWPForm=this.AV11WWPForm;
         aP1_CurrentElement=this.AV8CurrentElement;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ElementsToDelete = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV11WWPForm.gxTpr_Element.Count )
         {
            AV9Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV11WWPForm.gxTpr_Element.Item(AV13GXV1));
            if ( AV9Element.gxTpr_Wwpformelementparentid == AV8CurrentElement.gxTpr_Wwpformelementid )
            {
               AV10ElementsToDelete.Add(AV9Element.gxTpr_Wwpformelementid, 0);
            }
            AV13GXV1 = (int)(AV13GXV1+1);
         }
         AV14GXV2 = 1;
         while ( AV14GXV2 <= AV10ElementsToDelete.Count )
         {
            AV12WWPFormElementId = (short)(AV10ElementsToDelete.GetNumeric(AV14GXV2));
            GXt_SdtWWP_Form_Element1 = AV9Element;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV11WWPForm,  AV12WWPFormElementId, out  GXt_SdtWWP_Form_Element1) ;
            AV9Element = GXt_SdtWWP_Form_Element1;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_dfc_deleteelement(context ).execute( ref  AV11WWPForm, ref  AV9Element) ;
            AV14GXV2 = (int)(AV14GXV2+1);
         }
         AV8CurrentElement.gxTpr_Wwpformelementparentid = (short)(AV8CurrentElement.gxTpr_Wwpformelementid*-1);
         AV11WWPForm.gxTpr_Element.RemoveItem(AV11WWPForm.gxTpr_Element.IndexOf(AV8CurrentElement));
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
         AV10ElementsToDelete = new GxSimpleCollection<short>();
         AV9Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         GXt_SdtWWP_Form_Element1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         /* GeneXus formulas. */
      }

      private short AV12WWPFormElementId ;
      private int AV13GXV1 ;
      private int AV14GXV2 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV11WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV8CurrentElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element aP1_CurrentElement ;
      private GxSimpleCollection<short> AV10ElementsToDelete ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV9Element ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element GXt_SdtWWP_Form_Element1 ;
   }

}
