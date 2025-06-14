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
   public class wwp_df_getparentmultipledataid : GXProcedure
   {
      public wwp_df_getparentmultipledataid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_getparentmultipledataid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                           short aP1_WWPFormElementId ,
                           out short aP2_ParentMultipleDataId )
      {
         this.AV11WWPForm = aP0_WWPForm;
         this.AV12WWPFormElementId = aP1_WWPFormElementId;
         this.AV10ParentMultipleDataId = 0 ;
         initialize();
         ExecuteImpl();
         aP0_WWPForm=this.AV11WWPForm;
         aP2_ParentMultipleDataId=this.AV10ParentMultipleDataId;
      }

      public short executeUdp( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                               short aP1_WWPFormElementId )
      {
         execute(ref aP0_WWPForm, aP1_WWPFormElementId, out aP2_ParentMultipleDataId);
         return AV10ParentMultipleDataId ;
      }

      public void executeSubmit( ref GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                                 short aP1_WWPFormElementId ,
                                 out short aP2_ParentMultipleDataId )
      {
         this.AV11WWPForm = aP0_WWPForm;
         this.AV12WWPFormElementId = aP1_WWPFormElementId;
         this.AV10ParentMultipleDataId = 0 ;
         SubmitImpl();
         aP0_WWPForm=this.AV11WWPForm;
         aP2_ParentMultipleDataId=this.AV10ParentMultipleDataId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ParentMultipleDataId = 0;
         AV13WWPFormElementIdAux = AV12WWPFormElementId;
         /* Execute user subroutine: 'GETELEMENTBYID' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( AV8CurrentElement.gxTpr_Wwpformelementtype != 3 )
         {
            while ( ! (0==AV8CurrentElement.gxTpr_Wwpformelementparentid) )
            {
               AV13WWPFormElementIdAux = AV8CurrentElement.gxTpr_Wwpformelementparentid;
               /* Execute user subroutine: 'GETELEMENTBYID' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               if ( AV8CurrentElement.gxTpr_Wwpformelementtype == 3 )
               {
                  AV10ParentMultipleDataId = AV8CurrentElement.gxTpr_Wwpformelementid;
                  if (true) break;
               }
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'GETELEMENTBYID' Routine */
         returnInSub = false;
         AV14GXV1 = 1;
         while ( AV14GXV1 <= AV11WWPForm.gxTpr_Element.Count )
         {
            AV9ElementAux = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV11WWPForm.gxTpr_Element.Item(AV14GXV1));
            if ( ( AV9ElementAux.gxTpr_Wwpformelementid == AV13WWPFormElementIdAux ) && ( AV9ElementAux.gxTpr_Wwpformelementparentid >= 0 ) )
            {
               AV8CurrentElement = AV9ElementAux;
               if (true) break;
            }
            AV14GXV1 = (int)(AV14GXV1+1);
         }
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
         AV8CurrentElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV9ElementAux = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         /* GeneXus formulas. */
      }

      private short AV12WWPFormElementId ;
      private short AV10ParentMultipleDataId ;
      private short AV13WWPFormElementIdAux ;
      private int AV14GXV1 ;
      private bool returnInSub ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV11WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV8CurrentElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV9ElementAux ;
      private short aP2_ParentMultipleDataId ;
   }

}
