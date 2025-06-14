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
   public class wwp_df_getvalueforvalidation : GXProcedure
   {
      public wwp_df_getvalueforvalidation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_getvalueforvalidation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_WWPFormInstanceElementJson ,
                           out string aP1_ElementValue )
      {
         this.AV11WWPFormInstanceElementJson = aP0_WWPFormInstanceElementJson;
         this.AV9ElementValue = "" ;
         initialize();
         ExecuteImpl();
         aP1_ElementValue=this.AV9ElementValue;
      }

      public string executeUdp( string aP0_WWPFormInstanceElementJson )
      {
         execute(aP0_WWPFormInstanceElementJson, out aP1_ElementValue);
         return AV9ElementValue ;
      }

      public void executeSubmit( string aP0_WWPFormInstanceElementJson ,
                                 out string aP1_ElementValue )
      {
         this.AV11WWPFormInstanceElementJson = aP0_WWPFormInstanceElementJson;
         this.AV9ElementValue = "" ;
         SubmitImpl();
         aP1_ElementValue=this.AV9ElementValue;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10WWPFormInstanceElement.FromJSonString(AV11WWPFormInstanceElementJson, null);
         AV9ElementValue = "''";
         if ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 4 )
         {
            GXt_char1 = AV9ElementValue;
            new WorkWithPlus.workwithplus_dynamicforms.wwp_df_getdatevalueforvalidation(context ).execute(  AV10WWPFormInstanceElement.gxTpr_Wwpforminstanceelemdate, out  GXt_char1) ;
            AV9ElementValue = GXt_char1;
         }
         else if ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 5 )
         {
            GXt_char1 = AV9ElementValue;
            new WorkWithPlus.workwithplus_dynamicforms.wwp_df_getdatetimevalueforvalidation(context ).execute(  AV10WWPFormInstanceElement.gxTpr_Wwpforminstanceelemdatetime, out  GXt_char1) ;
            AV9ElementValue = GXt_char1;
         }
         else if ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 1 )
         {
            GXt_char1 = AV9ElementValue;
            new WorkWithPlus.workwithplus_dynamicforms.wwp_df_getbooleanvalueforvalidation(context ).execute(  AV10WWPFormInstanceElement.gxTpr_Wwpforminstanceelemboolean, out  GXt_char1) ;
            AV9ElementValue = GXt_char1;
         }
         else if ( ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 2 ) || ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 6 ) || ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 7 ) || ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 8 ) )
         {
            GXt_char1 = AV9ElementValue;
            new WorkWithPlus.workwithplus_dynamicforms.wwp_df_getcharvalueforvalidation(context ).execute(  AV10WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar, out  GXt_char1) ;
            AV9ElementValue = GXt_char1;
         }
         else if ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 3 )
         {
            GXt_char1 = AV9ElementValue;
            new WorkWithPlus.workwithplus_dynamicforms.wwp_df_getnumericvalueforvalidation(context ).execute(  AV10WWPFormInstanceElement.gxTpr_Wwpforminstanceelemnumeric, out  GXt_char1) ;
            AV9ElementValue = GXt_char1;
         }
         else if ( ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 9 ) || ( AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 10 ) )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10WWPFormInstanceElement.gxTpr_Wwpforminstanceelemblob)) )
            {
               AV9ElementValue = "'FILE_VALUE'";
            }
         }
         else
         {
            new GeneXus.Core.genexus.common.SdtLog(context).error("Unknown WWPFormElementDataType: "+context.localUtil.Format( (decimal)(AV10WWPFormInstanceElement.gxTpr_Wwpformelementdatatype), "Z9"), AV12Pgmname) ;
            AV9ElementValue = "";
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
         AV9ElementValue = "";
         AV10WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         GXt_char1 = "";
         AV12Pgmname = "";
         AV12Pgmname = "WorkWithPlus.DynamicForms.WWP_DF_GetValueForValidation";
         /* GeneXus formulas. */
         AV12Pgmname = "WorkWithPlus.DynamicForms.WWP_DF_GetValueForValidation";
      }

      private string GXt_char1 ;
      private string AV12Pgmname ;
      private string AV11WWPFormInstanceElementJson ;
      private string AV9ElementValue ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV10WWPFormInstanceElement ;
      private string aP1_ElementValue ;
   }

}
