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
   public class wc_notificationpanelloaddvcombo : GXProcedure
   {
      public wc_notificationpanelloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wc_notificationpanelloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ComboName ,
                           string aP1_SearchTxtParms ,
                           out string aP2_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17SearchTxtParms = aP1_SearchTxtParms;
         this.AV18Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP2_Combo_DataJson=this.AV18Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_SearchTxtParms )
      {
         execute(aP0_ComboName, aP1_SearchTxtParms, out aP2_Combo_DataJson);
         return AV18Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_SearchTxtParms ,
                                 out string aP2_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17SearchTxtParms = aP1_SearchTxtParms;
         this.AV18Combo_DataJson = "" ;
         SubmitImpl();
         aP2_Combo_DataJson=this.AV18Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10MaxItems = 10;
         AV12PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV17SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV17SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV17SearchTxtParms)) ? "" : StringUtil.Substring( AV17SearchTxtParms, 3, -1));
         AV11SkipItems = (short)(AV12PageIndex*AV10MaxItems);
         if ( StringUtil.StrCmp(AV16ComboName, "GroupList") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_GROUPLIST' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "RecipientList") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RECIPIENTLIST' */
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
         /* 'LOADCOMBOITEMS_GROUPLIST' Routine */
         returnInSub = false;
         AV24GXV2 = 1;
         GXt_objcol_SdtSDT_ResidentPackage_SDT_ResidentPackageItem1 = AV23GXV1;
         new dp_residentaccessgroups(context ).execute( out  GXt_objcol_SdtSDT_ResidentPackage_SDT_ResidentPackageItem1) ;
         AV23GXV1 = GXt_objcol_SdtSDT_ResidentPackage_SDT_ResidentPackageItem1;
         while ( AV24GXV2 <= AV23GXV1.Count )
         {
            AV22GroupList_DPItem = ((SdtSDT_ResidentPackage_SDT_ResidentPackageItem)AV23GXV1.Item(AV24GXV2));
            AV15Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( AV22GroupList_DPItem.gxTpr_Residentpackageid.ToString());
            AV20ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV20ComboTitles.Add(AV22GroupList_DPItem.gxTpr_Residentpackagename, 0);
            AV20ComboTitles.Add(AV22GroupList_DPItem.gxTpr_Residentpackagename, 0);
            AV15Combo_DataItem.gxTpr_Title = AV20ComboTitles.ToJSonString(false);
            AV14Combo_Data.Add(AV15Combo_DataItem, 0);
            AV24GXV2 = (int)(AV24GXV2+1);
         }
         AV14Combo_Data.Sort("Title");
         new WorkWithPlus.workwithplus_web.wwp_extendedcombopagedata(context ).execute( ref  AV14Combo_Data,  AV11SkipItems,  AV10MaxItems) ;
         AV18Combo_DataJson = AV14Combo_Data.ToJSonString(false);
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_RECIPIENTLIST' Routine */
         returnInSub = false;
         AV26GXV4 = 1;
         GXt_objcol_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem2 = AV25GXV3;
         new dp_locationresident(context ).execute( out  GXt_objcol_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem2) ;
         AV25GXV3 = GXt_objcol_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem2;
         while ( AV26GXV4 <= AV25GXV3.Count )
         {
            AV21RecipientList_DPItem = ((SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem)AV25GXV3.Item(AV26GXV4));
            AV15Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( AV21RecipientList_DPItem.gxTpr_Residentid.ToString());
            AV20ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV20ComboTitles.Add(AV21RecipientList_DPItem.gxTpr_Residentfullname, 0);
            AV20ComboTitles.Add(AV21RecipientList_DPItem.gxTpr_Residentfullname, 0);
            AV15Combo_DataItem.gxTpr_Title = AV20ComboTitles.ToJSonString(false);
            AV14Combo_Data.Add(AV15Combo_DataItem, 0);
            AV26GXV4 = (int)(AV26GXV4+1);
         }
         AV14Combo_Data.Sort("Title");
         new WorkWithPlus.workwithplus_web.wwp_extendedcombopagedata(context ).execute( ref  AV14Combo_Data,  AV11SkipItems,  AV10MaxItems) ;
         AV18Combo_DataJson = AV14Combo_Data.ToJSonString(false);
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
         AV18Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13SearchTxt = "";
         AV23GXV1 = new GXBaseCollection<SdtSDT_ResidentPackage_SDT_ResidentPackageItem>( context, "SDT_ResidentPackageItem", "Comforta_version2");
         GXt_objcol_SdtSDT_ResidentPackage_SDT_ResidentPackageItem1 = new GXBaseCollection<SdtSDT_ResidentPackage_SDT_ResidentPackageItem>( context, "SDT_ResidentPackageItem", "Comforta_version2");
         AV22GroupList_DPItem = new SdtSDT_ResidentPackage_SDT_ResidentPackageItem(context);
         AV15Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV20ComboTitles = new GxSimpleCollection<string>();
         AV14Combo_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV25GXV3 = new GXBaseCollection<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem>( context, "SDT_ResidentAddressBookItem", "Comforta_version2");
         GXt_objcol_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem2 = new GXBaseCollection<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem>( context, "SDT_ResidentAddressBookItem", "Comforta_version2");
         AV21RecipientList_DPItem = new SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem(context);
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV10MaxItems ;
      private int AV24GXV2 ;
      private int AV26GXV4 ;
      private bool returnInSub ;
      private string AV18Combo_DataJson ;
      private string AV16ComboName ;
      private string AV17SearchTxtParms ;
      private string AV13SearchTxt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<SdtSDT_ResidentPackage_SDT_ResidentPackageItem> AV23GXV1 ;
      private GXBaseCollection<SdtSDT_ResidentPackage_SDT_ResidentPackageItem> GXt_objcol_SdtSDT_ResidentPackage_SDT_ResidentPackageItem1 ;
      private SdtSDT_ResidentPackage_SDT_ResidentPackageItem AV22GroupList_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GxSimpleCollection<string> AV20ComboTitles ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private GXBaseCollection<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem> AV25GXV3 ;
      private GXBaseCollection<SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem> GXt_objcol_SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem2 ;
      private SdtSDT_ResidentAddressBook_SDT_ResidentAddressBookItem AV21RecipientList_DPItem ;
      private string aP2_Combo_DataJson ;
   }

}
