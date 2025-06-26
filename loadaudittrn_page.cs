using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class loadaudittrn_page : GXProcedure
   {
      public loadaudittrn_page( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadaudittrn_page( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_Trn_PageId ,
                           Guid aP3_LocationId ,
                           string aP4_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17Trn_PageId = aP2_Trn_PageId;
         this.AV19LocationId = aP3_LocationId;
         this.AV15ActualMode = aP4_ActualMode;
         initialize();
         ExecuteImpl();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_Trn_PageId ,
                                 Guid aP3_LocationId ,
                                 string aP4_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17Trn_PageId = aP2_Trn_PageId;
         this.AV19LocationId = aP3_LocationId;
         this.AV15ActualMode = aP4_ActualMode;
         SubmitImpl();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV14SaveOldValues, "Y") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV15ActualMode, "DLT") == 0 ) || ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 ) )
            {
               /* Execute user subroutine: 'LOADOLDVALUES' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'LOADNEWVALUES' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADOLDVALUES' Routine */
         returnInSub = false;
         /* Using cursor P00AO2 */
         pr_default.execute(0, new Object[] {AV17Trn_PageId, AV19LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00AO2_A29LocationId[0];
            A392Trn_PageId = P00AO2_A392Trn_PageId[0];
            A397Trn_PageName = P00AO2_A397Trn_PageName[0];
            A420PageJsonContent = P00AO2_A420PageJsonContent[0];
            n420PageJsonContent = P00AO2_n420PageJsonContent[0];
            A421PageGJSHtml = P00AO2_A421PageGJSHtml[0];
            n421PageGJSHtml = P00AO2_n421PageGJSHtml[0];
            A422PageGJSJson = P00AO2_A422PageGJSJson[0];
            n422PageGJSJson = P00AO2_n422PageGJSJson[0];
            A423PageIsPublished = P00AO2_A423PageIsPublished[0];
            n423PageIsPublished = P00AO2_n423PageIsPublished[0];
            A492PageIsPredefined = P00AO2_A492PageIsPredefined[0];
            A429PageIsContentPage = P00AO2_A429PageIsContentPage[0];
            n429PageIsContentPage = P00AO2_n429PageIsContentPage[0];
            A502PageIsDynamicForm = P00AO2_A502PageIsDynamicForm[0];
            A505PageIsWebLinkPage = P00AO2_A505PageIsWebLinkPage[0];
            A424PageChildren = P00AO2_A424PageChildren[0];
            n424PageChildren = P00AO2_n424PageChildren[0];
            A58ProductServiceId = P00AO2_A58ProductServiceId[0];
            n58ProductServiceId = P00AO2_n58ProductServiceId[0];
            A11OrganisationId = P00AO2_A11OrganisationId[0];
            AV11AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_Page";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Trn_PageId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A392Trn_PageId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Trn_PageName";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Name", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A397Trn_PageName;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LocationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Location Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A29LocationId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageJsonContent";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Json Content", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A420PageJsonContent;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageGJSHtml";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GJSHtml", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A421PageGJSHtml;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageGJSJson";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GJSJson", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A422PageGJSJson;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsPublished";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Is Published", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A423PageIsPublished);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsPredefined";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Predefined", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A492PageIsPredefined);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsContentPage";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Content Page", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A429PageIsContentPage);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsDynamicForm";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Dynamic Form", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A502PageIsDynamicForm);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsWebLinkPage";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Web Link Page", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A505PageIsWebLinkPage);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageChildren";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Children", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A424PageChildren;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ProductServiceId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Product Service Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A58ProductServiceId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "OrganisationId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Organisation Id", "");
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A11OrganisationId.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADNEWVALUES' Routine */
         returnInSub = false;
         /* Using cursor P00AO3 */
         pr_default.execute(1, new Object[] {AV17Trn_PageId, AV19LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = P00AO3_A29LocationId[0];
            A392Trn_PageId = P00AO3_A392Trn_PageId[0];
            A397Trn_PageName = P00AO3_A397Trn_PageName[0];
            A420PageJsonContent = P00AO3_A420PageJsonContent[0];
            n420PageJsonContent = P00AO3_n420PageJsonContent[0];
            A421PageGJSHtml = P00AO3_A421PageGJSHtml[0];
            n421PageGJSHtml = P00AO3_n421PageGJSHtml[0];
            A422PageGJSJson = P00AO3_A422PageGJSJson[0];
            n422PageGJSJson = P00AO3_n422PageGJSJson[0];
            A423PageIsPublished = P00AO3_A423PageIsPublished[0];
            n423PageIsPublished = P00AO3_n423PageIsPublished[0];
            A492PageIsPredefined = P00AO3_A492PageIsPredefined[0];
            A429PageIsContentPage = P00AO3_A429PageIsContentPage[0];
            n429PageIsContentPage = P00AO3_n429PageIsContentPage[0];
            A502PageIsDynamicForm = P00AO3_A502PageIsDynamicForm[0];
            A505PageIsWebLinkPage = P00AO3_A505PageIsWebLinkPage[0];
            A424PageChildren = P00AO3_A424PageChildren[0];
            n424PageChildren = P00AO3_n424PageChildren[0];
            A58ProductServiceId = P00AO3_A58ProductServiceId[0];
            n58ProductServiceId = P00AO3_n58ProductServiceId[0];
            A11OrganisationId = P00AO3_A11OrganisationId[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "Trn_Page";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Trn_PageId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A392Trn_PageId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "Trn_PageName";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Name", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A397Trn_PageName;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "LocationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Location Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A29LocationId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageJsonContent";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Json Content", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A420PageJsonContent;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageGJSHtml";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GJSHtml", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A421PageGJSHtml;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageGJSJson";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "GJSJson", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A422PageGJSJson;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsPublished";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Is Published", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A423PageIsPublished);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsPredefined";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Predefined", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A492PageIsPredefined);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsContentPage";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Content Page", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A429PageIsContentPage);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsDynamicForm";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Dynamic Form", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A502PageIsDynamicForm);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageIsWebLinkPage";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Page Is Web Link Page", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A505PageIsWebLinkPage);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PageChildren";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Children", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A424PageChildren;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ProductServiceId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Product Service Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A58ProductServiceId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "OrganisationId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = context.GetMessage( "Organisation Id", "");
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A11OrganisationId.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV22GXV1 = 1;
               while ( AV22GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV22GXV1));
                  AV23GXV2 = 1;
                  while ( AV23GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                  {
                     AV13AuditingObjectRecordItemAttributeItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV23GXV2));
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "Trn_PageId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A392Trn_PageId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "Trn_PageName") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A397Trn_PageName;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "LocationId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A29LocationId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageJsonContent") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A420PageJsonContent;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageGJSHtml") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A421PageGJSHtml;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageGJSJson") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A422PageGJSJson;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageIsPublished") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A423PageIsPublished);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageIsPredefined") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A492PageIsPredefined);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageIsContentPage") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A429PageIsContentPage);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageIsDynamicForm") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A502PageIsDynamicForm);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageIsWebLinkPage") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A505PageIsWebLinkPage);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PageChildren") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A424PageChildren;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ProductServiceId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A58ProductServiceId.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "OrganisationId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A11OrganisationId.ToString();
                     }
                     AV23GXV2 = (int)(AV23GXV2+1);
                  }
                  AV22GXV1 = (int)(AV22GXV1+1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         P00AO2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AO2_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         P00AO2_A397Trn_PageName = new string[] {""} ;
         P00AO2_A420PageJsonContent = new string[] {""} ;
         P00AO2_n420PageJsonContent = new bool[] {false} ;
         P00AO2_A421PageGJSHtml = new string[] {""} ;
         P00AO2_n421PageGJSHtml = new bool[] {false} ;
         P00AO2_A422PageGJSJson = new string[] {""} ;
         P00AO2_n422PageGJSJson = new bool[] {false} ;
         P00AO2_A423PageIsPublished = new bool[] {false} ;
         P00AO2_n423PageIsPublished = new bool[] {false} ;
         P00AO2_A492PageIsPredefined = new bool[] {false} ;
         P00AO2_A429PageIsContentPage = new bool[] {false} ;
         P00AO2_n429PageIsContentPage = new bool[] {false} ;
         P00AO2_A502PageIsDynamicForm = new bool[] {false} ;
         P00AO2_A505PageIsWebLinkPage = new bool[] {false} ;
         P00AO2_A424PageChildren = new string[] {""} ;
         P00AO2_n424PageChildren = new bool[] {false} ;
         P00AO2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00AO2_n58ProductServiceId = new bool[] {false} ;
         P00AO2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A392Trn_PageId = Guid.Empty;
         A397Trn_PageName = "";
         A420PageJsonContent = "";
         A421PageGJSHtml = "";
         A422PageGJSJson = "";
         A424PageChildren = "";
         A58ProductServiceId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV12AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00AO3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00AO3_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         P00AO3_A397Trn_PageName = new string[] {""} ;
         P00AO3_A420PageJsonContent = new string[] {""} ;
         P00AO3_n420PageJsonContent = new bool[] {false} ;
         P00AO3_A421PageGJSHtml = new string[] {""} ;
         P00AO3_n421PageGJSHtml = new bool[] {false} ;
         P00AO3_A422PageGJSJson = new string[] {""} ;
         P00AO3_n422PageGJSJson = new bool[] {false} ;
         P00AO3_A423PageIsPublished = new bool[] {false} ;
         P00AO3_n423PageIsPublished = new bool[] {false} ;
         P00AO3_A492PageIsPredefined = new bool[] {false} ;
         P00AO3_A429PageIsContentPage = new bool[] {false} ;
         P00AO3_n429PageIsContentPage = new bool[] {false} ;
         P00AO3_A502PageIsDynamicForm = new bool[] {false} ;
         P00AO3_A505PageIsWebLinkPage = new bool[] {false} ;
         P00AO3_A424PageChildren = new string[] {""} ;
         P00AO3_n424PageChildren = new bool[] {false} ;
         P00AO3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00AO3_n58ProductServiceId = new bool[] {false} ;
         P00AO3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.loadaudittrn_page__default(),
            new Object[][] {
                new Object[] {
               P00AO2_A29LocationId, P00AO2_A392Trn_PageId, P00AO2_A397Trn_PageName, P00AO2_A420PageJsonContent, P00AO2_n420PageJsonContent, P00AO2_A421PageGJSHtml, P00AO2_n421PageGJSHtml, P00AO2_A422PageGJSJson, P00AO2_n422PageGJSJson, P00AO2_A423PageIsPublished,
               P00AO2_n423PageIsPublished, P00AO2_A492PageIsPredefined, P00AO2_A429PageIsContentPage, P00AO2_n429PageIsContentPage, P00AO2_A502PageIsDynamicForm, P00AO2_A505PageIsWebLinkPage, P00AO2_A424PageChildren, P00AO2_n424PageChildren, P00AO2_A58ProductServiceId, P00AO2_n58ProductServiceId,
               P00AO2_A11OrganisationId
               }
               , new Object[] {
               P00AO3_A29LocationId, P00AO3_A392Trn_PageId, P00AO3_A397Trn_PageName, P00AO3_A420PageJsonContent, P00AO3_n420PageJsonContent, P00AO3_A421PageGJSHtml, P00AO3_n421PageGJSHtml, P00AO3_A422PageGJSJson, P00AO3_n422PageGJSJson, P00AO3_A423PageIsPublished,
               P00AO3_n423PageIsPublished, P00AO3_A492PageIsPredefined, P00AO3_A429PageIsContentPage, P00AO3_n429PageIsContentPage, P00AO3_A502PageIsDynamicForm, P00AO3_A505PageIsWebLinkPage, P00AO3_A424PageChildren, P00AO3_n424PageChildren, P00AO3_A58ProductServiceId, P00AO3_n58ProductServiceId,
               P00AO3_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private bool returnInSub ;
      private bool n420PageJsonContent ;
      private bool n421PageGJSHtml ;
      private bool n422PageGJSJson ;
      private bool A423PageIsPublished ;
      private bool n423PageIsPublished ;
      private bool A492PageIsPredefined ;
      private bool A429PageIsContentPage ;
      private bool n429PageIsContentPage ;
      private bool A502PageIsDynamicForm ;
      private bool A505PageIsWebLinkPage ;
      private bool n424PageChildren ;
      private bool n58ProductServiceId ;
      private string A420PageJsonContent ;
      private string A421PageGJSHtml ;
      private string A422PageGJSJson ;
      private string A424PageChildren ;
      private string A397Trn_PageName ;
      private Guid AV17Trn_PageId ;
      private Guid AV19LocationId ;
      private Guid A29LocationId ;
      private Guid A392Trn_PageId ;
      private Guid A58ProductServiceId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject AV11AuditingObject ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00AO2_A29LocationId ;
      private Guid[] P00AO2_A392Trn_PageId ;
      private string[] P00AO2_A397Trn_PageName ;
      private string[] P00AO2_A420PageJsonContent ;
      private bool[] P00AO2_n420PageJsonContent ;
      private string[] P00AO2_A421PageGJSHtml ;
      private bool[] P00AO2_n421PageGJSHtml ;
      private string[] P00AO2_A422PageGJSJson ;
      private bool[] P00AO2_n422PageGJSJson ;
      private bool[] P00AO2_A423PageIsPublished ;
      private bool[] P00AO2_n423PageIsPublished ;
      private bool[] P00AO2_A492PageIsPredefined ;
      private bool[] P00AO2_A429PageIsContentPage ;
      private bool[] P00AO2_n429PageIsContentPage ;
      private bool[] P00AO2_A502PageIsDynamicForm ;
      private bool[] P00AO2_A505PageIsWebLinkPage ;
      private string[] P00AO2_A424PageChildren ;
      private bool[] P00AO2_n424PageChildren ;
      private Guid[] P00AO2_A58ProductServiceId ;
      private bool[] P00AO2_n58ProductServiceId ;
      private Guid[] P00AO2_A11OrganisationId ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
      private Guid[] P00AO3_A29LocationId ;
      private Guid[] P00AO3_A392Trn_PageId ;
      private string[] P00AO3_A397Trn_PageName ;
      private string[] P00AO3_A420PageJsonContent ;
      private bool[] P00AO3_n420PageJsonContent ;
      private string[] P00AO3_A421PageGJSHtml ;
      private bool[] P00AO3_n421PageGJSHtml ;
      private string[] P00AO3_A422PageGJSJson ;
      private bool[] P00AO3_n422PageGJSJson ;
      private bool[] P00AO3_A423PageIsPublished ;
      private bool[] P00AO3_n423PageIsPublished ;
      private bool[] P00AO3_A492PageIsPredefined ;
      private bool[] P00AO3_A429PageIsContentPage ;
      private bool[] P00AO3_n429PageIsContentPage ;
      private bool[] P00AO3_A502PageIsDynamicForm ;
      private bool[] P00AO3_A505PageIsWebLinkPage ;
      private string[] P00AO3_A424PageChildren ;
      private bool[] P00AO3_n424PageChildren ;
      private Guid[] P00AO3_A58ProductServiceId ;
      private bool[] P00AO3_n58ProductServiceId ;
      private Guid[] P00AO3_A11OrganisationId ;
   }

   public class loadaudittrn_page__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AO2;
          prmP00AO2 = new Object[] {
          new ParDef("AV17Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00AO3;
          prmP00AO3 = new Object[] {
          new ParDef("AV17Trn_PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AO2", "SELECT LocationId, Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsPredefined, PageIsContentPage, PageIsDynamicForm, PageIsWebLinkPage, PageChildren, ProductServiceId, OrganisationId FROM Trn_Page WHERE Trn_PageId = :AV17Trn_PageId and LocationId = :AV19LocationId ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AO2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AO3", "SELECT LocationId, Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsPredefined, PageIsContentPage, PageIsDynamicForm, PageIsWebLinkPage, PageChildren, ProductServiceId, OrganisationId FROM Trn_Page WHERE Trn_PageId = :AV17Trn_PageId and LocationId = :AV19LocationId ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AO3,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((bool[]) buf[11])[0] = rslt.getBool(8);
                ((bool[]) buf[12])[0] = rslt.getBool(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((bool[]) buf[14])[0] = rslt.getBool(10);
                ((bool[]) buf[15])[0] = rslt.getBool(11);
                ((string[]) buf[16])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((Guid[]) buf[18])[0] = rslt.getGuid(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((Guid[]) buf[20])[0] = rslt.getGuid(14);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((bool[]) buf[11])[0] = rslt.getBool(8);
                ((bool[]) buf[12])[0] = rslt.getBool(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((bool[]) buf[14])[0] = rslt.getBool(10);
                ((bool[]) buf[15])[0] = rslt.getBool(11);
                ((string[]) buf[16])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((Guid[]) buf[18])[0] = rslt.getGuid(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((Guid[]) buf[20])[0] = rslt.getGuid(14);
                return;
       }
    }

 }

}
