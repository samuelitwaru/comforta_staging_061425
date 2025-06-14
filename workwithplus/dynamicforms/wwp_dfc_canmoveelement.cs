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
   public class wwp_dfc_canmoveelement : GXProcedure
   {
      public wwp_dfc_canmoveelement( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_dfc_canmoveelement( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                           GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element aP1_CurrentFormElement ,
                           out bool aP2_IsFirstElement ,
                           out bool aP3_IsLastElement )
      {
         this.AV12WWPForm = aP0_WWPForm;
         this.AV8CurrentFormElement = aP1_CurrentFormElement;
         this.AV10IsFirstElement = false ;
         this.AV11IsLastElement = false ;
         initialize();
         ExecuteImpl();
         aP2_IsFirstElement=this.AV10IsFirstElement;
         aP3_IsLastElement=this.AV11IsLastElement;
      }

      public bool executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                              GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element aP1_CurrentFormElement ,
                              out bool aP2_IsFirstElement )
      {
         execute(aP0_WWPForm, aP1_CurrentFormElement, out aP2_IsFirstElement, out aP3_IsLastElement);
         return AV11IsLastElement ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form aP0_WWPForm ,
                                 GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element aP1_CurrentFormElement ,
                                 out bool aP2_IsFirstElement ,
                                 out bool aP3_IsLastElement )
      {
         this.AV12WWPForm = aP0_WWPForm;
         this.AV8CurrentFormElement = aP1_CurrentFormElement;
         this.AV10IsFirstElement = false ;
         this.AV11IsLastElement = false ;
         SubmitImpl();
         aP2_IsFirstElement=this.AV10IsFirstElement;
         aP3_IsLastElement=this.AV11IsLastElement;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ElementFound = false;
         AV10IsFirstElement = true;
         AV11IsLastElement = true;
         AV14GXV1 = 1;
         while ( AV14GXV1 <= AV12WWPForm.gxTpr_Element.Count )
         {
            AV13WWPFormElement = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV12WWPForm.gxTpr_Element.Item(AV14GXV1));
            if ( AV13WWPFormElement.gxTpr_Wwpformelementid == AV8CurrentFormElement.gxTpr_Wwpformelementid )
            {
               AV9ElementFound = true;
            }
            else
            {
               if ( AV13WWPFormElement.gxTpr_Wwpformelementparentid == AV8CurrentFormElement.gxTpr_Wwpformelementparentid )
               {
                  if ( ! AV9ElementFound )
                  {
                     AV10IsFirstElement = false;
                  }
                  else
                  {
                     AV11IsLastElement = false;
                     if (true) break;
                  }
               }
            }
            AV14GXV1 = (int)(AV14GXV1+1);
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
         AV13WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         /* GeneXus formulas. */
      }

      private int AV14GXV1 ;
      private bool AV10IsFirstElement ;
      private bool AV11IsLastElement ;
      private bool AV9ElementFound ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV12WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV8CurrentFormElement ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV13WWPFormElement ;
      private bool aP2_IsFirstElement ;
      private bool aP3_IsLastElement ;
   }

}
