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
   public class wwp_dfc_moveelement : GXProcedure
   {
      public wwp_dfc_moveelement( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_dfc_moveelement( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_SessionId ,
                           short aP1_WWPFormElementId ,
                           bool aP2_MoveUp )
      {
         this.AV16SessionId = aP0_SessionId;
         this.AV19WWPFormElementId = aP1_WWPFormElementId;
         this.AV15MoveUp = aP2_MoveUp;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_SessionId ,
                                 short aP1_WWPFormElementId ,
                                 bool aP2_MoveUp )
      {
         this.AV16SessionId = aP0_SessionId;
         this.AV19WWPFormElementId = aP1_WWPFormElementId;
         this.AV15MoveUp = aP2_MoveUp;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtWWP_Form1 = AV18WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV16SessionId, out  GXt_SdtWWP_Form1) ;
         AV18WWPForm = GXt_SdtWWP_Form1;
         GXt_SdtWWP_Form_Element2 = AV9CurrentElement;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getelementbyid(context ).execute( ref  AV18WWPForm,  AV19WWPFormElementId, out  GXt_SdtWWP_Form_Element2) ;
         AV9CurrentElement = GXt_SdtWWP_Form_Element2;
         AV10CurrentElementFound = false;
         AV14ElementToSwitchFound = false;
         AV20GXV1 = 1;
         while ( AV20GXV1 <= AV18WWPForm.gxTpr_Element.Count )
         {
            AV12Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV18WWPForm.gxTpr_Element.Item(AV20GXV1));
            if ( AV12Element == AV9CurrentElement )
            {
               AV10CurrentElementFound = true;
               if ( AV15MoveUp )
               {
                  if (true) break;
               }
            }
            else
            {
               if ( AV12Element.gxTpr_Wwpformelementparentid == AV9CurrentElement.gxTpr_Wwpformelementparentid )
               {
                  if ( AV15MoveUp )
                  {
                     AV13ElementToSwitch = AV12Element;
                     AV14ElementToSwitchFound = true;
                  }
                  else
                  {
                     if ( AV10CurrentElementFound )
                     {
                        AV13ElementToSwitch = AV12Element;
                        AV14ElementToSwitchFound = true;
                        if (true) break;
                     }
                  }
               }
            }
            AV20GXV1 = (int)(AV20GXV1+1);
         }
         if ( AV14ElementToSwitchFound )
         {
            AV8AuxOrder = AV13ElementToSwitch.gxTpr_Wwpformelementorderindex;
            AV13ElementToSwitch.gxTpr_Wwpformelementorderindex = AV9CurrentElement.gxTpr_Wwpformelementorderindex;
            AV9CurrentElement.gxTpr_Wwpformelementorderindex = AV8AuxOrder;
            AV18WWPForm.gxTpr_Element.Sort("WWPFormElementOrderIndex");
            if ( AV9CurrentElement.gxTpr_Wwpformelementtype == 5 )
            {
               AV11CurrentStepIndex = 0;
               AV21GXV2 = 1;
               while ( AV21GXV2 <= AV18WWPForm.gxTpr_Element.Count )
               {
                  AV12Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV18WWPForm.gxTpr_Element.Item(AV21GXV2));
                  if ( ( AV12Element.gxTpr_Wwpformelementtype == 5 ) && (0==AV12Element.gxTpr_Wwpformelementparentid) )
                  {
                     AV11CurrentStepIndex = (short)(AV11CurrentStepIndex+1);
                     if ( AV12Element.gxTpr_Wwpformelementid == AV9CurrentElement.gxTpr_Wwpformelementid )
                     {
                        if (true) break;
                     }
                  }
                  AV21GXV2 = (int)(AV21GXV2+1);
               }
               AV17WebSession.Set("WWPDynFormCreation_DefaultStep", StringUtil.Trim( StringUtil.Str( (decimal)(AV11CurrentStepIndex), 4, 0)));
            }
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_saveformdefinition(context ).execute(  AV16SessionId,  AV18WWPForm) ;
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
         AV18WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         GXt_SdtWWP_Form1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV9CurrentElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         GXt_SdtWWP_Form_Element2 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV12Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV13ElementToSwitch = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV17WebSession = context.GetSession();
         /* GeneXus formulas. */
      }

      private short AV16SessionId ;
      private short AV19WWPFormElementId ;
      private short AV8AuxOrder ;
      private short AV11CurrentStepIndex ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private bool AV15MoveUp ;
      private bool AV10CurrentElementFound ;
      private bool AV14ElementToSwitchFound ;
      private IGxSession AV17WebSession ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV18WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form1 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV9CurrentElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element GXt_SdtWWP_Form_Element2 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV12Element ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV13ElementToSwitch ;
   }

}
