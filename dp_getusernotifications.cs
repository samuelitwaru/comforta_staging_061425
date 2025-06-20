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
   public class dp_getusernotifications : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public dp_getusernotifications( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public dp_getusernotifications( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_type ,
                           GxSimpleCollection<long> aP1_NotificationDefinitionIdCollection ,
                           string aP2_searchKey ,
                           out GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> aP3_Gxm2rootcol )
      {
         this.AV8type = aP0_type;
         this.AV9NotificationDefinitionIdCollection = aP1_NotificationDefinitionIdCollection;
         this.AV11searchKey = aP2_searchKey;
         this.Gxm2rootcol = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2") ;
         initialize();
         ExecuteImpl();
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> executeUdp( string aP0_type ,
                                                                                              GxSimpleCollection<long> aP1_NotificationDefinitionIdCollection ,
                                                                                              string aP2_searchKey )
      {
         execute(aP0_type, aP1_NotificationDefinitionIdCollection, aP2_searchKey, out aP3_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( string aP0_type ,
                                 GxSimpleCollection<long> aP1_NotificationDefinitionIdCollection ,
                                 string aP2_searchKey ,
                                 out GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> aP3_Gxm2rootcol )
      {
         this.AV8type = aP0_type;
         this.AV9NotificationDefinitionIdCollection = aP1_NotificationDefinitionIdCollection;
         this.AV11searchKey = aP2_searchKey;
         this.Gxm2rootcol = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2") ;
         SubmitImpl();
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15Udparg3 = new prc_getloggedinuserid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A128WWPNotificationDefinitionId ,
                                              AV9NotificationDefinitionIdCollection ,
                                              AV9NotificationDefinitionIdCollection.Count ,
                                              AV8type ,
                                              AV11searchKey ,
                                              A187WWPNotificationIsRead ,
                                              A112WWPUserExtendedId ,
                                              AV15Udparg3 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P000Q2 */
         pr_default.execute(0, new Object[] {AV15Udparg3, AV11searchKey, AV11searchKey});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A183WWPNotificationShortDescriptio = P000Q2_A183WWPNotificationShortDescriptio[0];
            A182WWPNotificationTitle = P000Q2_A182WWPNotificationTitle[0];
            A187WWPNotificationIsRead = P000Q2_A187WWPNotificationIsRead[0];
            A128WWPNotificationDefinitionId = P000Q2_A128WWPNotificationDefinitionId[0];
            A112WWPUserExtendedId = P000Q2_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = P000Q2_n112WWPUserExtendedId[0];
            A127WWPNotificationId = P000Q2_A127WWPNotificationId[0];
            A181WWPNotificationIcon = P000Q2_A181WWPNotificationIcon[0];
            A184WWPNotificationLink = P000Q2_A184WWPNotificationLink[0];
            A165WWPNotificationMetadata = P000Q2_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = P000Q2_n165WWPNotificationMetadata[0];
            A129WWPNotificationCreated = P000Q2_A129WWPNotificationCreated[0];
            Gxm1usdtnotificationsdata = new SdtUSDTNotificationsData_USDTNotificationsDataItem(context);
            Gxm2rootcol.Add(Gxm1usdtnotificationsdata, 0);
            Gxm1usdtnotificationsdata.gxTpr_Notificationid = (int)(A127WWPNotificationId);
            Gxm1usdtnotificationsdata.gxTpr_Notificationiconclass = "NotificationFontIcon"+" "+A181WWPNotificationIcon;
            Gxm1usdtnotificationsdata.gxTpr_Notificationtitle = A182WWPNotificationTitle;
            Gxm1usdtnotificationsdata.gxTpr_Notificationdescription = A183WWPNotificationShortDescriptio;
            Gxm1usdtnotificationsdata.gxTpr_Notificationdatetime = A129WWPNotificationCreated;
            Gxm1usdtnotificationsdata.gxTpr_Notificationlink = A184WWPNotificationLink;
            Gxm1usdtnotificationsdata.gxTpr_Notificationdefinitionid = A128WWPNotificationDefinitionId;
            Gxm1usdtnotificationsdata.gxTpr_Notificationisread = A187WWPNotificationIsRead;
            Gxm1usdtnotificationsdata.gxTpr_Notificationmetadata = A165WWPNotificationMetadata;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV15Udparg3 = "";
         A112WWPUserExtendedId = "";
         P000Q2_A183WWPNotificationShortDescriptio = new string[] {""} ;
         P000Q2_A182WWPNotificationTitle = new string[] {""} ;
         P000Q2_A187WWPNotificationIsRead = new bool[] {false} ;
         P000Q2_A128WWPNotificationDefinitionId = new long[1] ;
         P000Q2_A112WWPUserExtendedId = new string[] {""} ;
         P000Q2_n112WWPUserExtendedId = new bool[] {false} ;
         P000Q2_A127WWPNotificationId = new long[1] ;
         P000Q2_A181WWPNotificationIcon = new string[] {""} ;
         P000Q2_A184WWPNotificationLink = new string[] {""} ;
         P000Q2_A165WWPNotificationMetadata = new string[] {""} ;
         P000Q2_n165WWPNotificationMetadata = new bool[] {false} ;
         P000Q2_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         A183WWPNotificationShortDescriptio = "";
         A182WWPNotificationTitle = "";
         A181WWPNotificationIcon = "";
         A184WWPNotificationLink = "";
         A165WWPNotificationMetadata = "";
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Gxm1usdtnotificationsdata = new SdtUSDTNotificationsData_USDTNotificationsDataItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dp_getusernotifications__default(),
            new Object[][] {
                new Object[] {
               P000Q2_A183WWPNotificationShortDescriptio, P000Q2_A182WWPNotificationTitle, P000Q2_A187WWPNotificationIsRead, P000Q2_A128WWPNotificationDefinitionId, P000Q2_A112WWPUserExtendedId, P000Q2_n112WWPUserExtendedId, P000Q2_A127WWPNotificationId, P000Q2_A181WWPNotificationIcon, P000Q2_A184WWPNotificationLink, P000Q2_A165WWPNotificationMetadata,
               P000Q2_n165WWPNotificationMetadata, P000Q2_A129WWPNotificationCreated
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9NotificationDefinitionIdCollection_Count ;
      private long A128WWPNotificationDefinitionId ;
      private long A127WWPNotificationId ;
      private string AV8type ;
      private string A112WWPUserExtendedId ;
      private DateTime A129WWPNotificationCreated ;
      private bool A187WWPNotificationIsRead ;
      private bool n112WWPUserExtendedId ;
      private bool n165WWPNotificationMetadata ;
      private string A165WWPNotificationMetadata ;
      private string AV11searchKey ;
      private string AV15Udparg3 ;
      private string A183WWPNotificationShortDescriptio ;
      private string A182WWPNotificationTitle ;
      private string A181WWPNotificationIcon ;
      private string A184WWPNotificationLink ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV9NotificationDefinitionIdCollection ;
      private GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private string[] P000Q2_A183WWPNotificationShortDescriptio ;
      private string[] P000Q2_A182WWPNotificationTitle ;
      private bool[] P000Q2_A187WWPNotificationIsRead ;
      private long[] P000Q2_A128WWPNotificationDefinitionId ;
      private string[] P000Q2_A112WWPUserExtendedId ;
      private bool[] P000Q2_n112WWPUserExtendedId ;
      private long[] P000Q2_A127WWPNotificationId ;
      private string[] P000Q2_A181WWPNotificationIcon ;
      private string[] P000Q2_A184WWPNotificationLink ;
      private string[] P000Q2_A165WWPNotificationMetadata ;
      private bool[] P000Q2_n165WWPNotificationMetadata ;
      private DateTime[] P000Q2_A129WWPNotificationCreated ;
      private SdtUSDTNotificationsData_USDTNotificationsDataItem Gxm1usdtnotificationsdata ;
      private GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> aP3_Gxm2rootcol ;
   }

   public class dp_getusernotifications__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000Q2( IGxContext context ,
                                             long A128WWPNotificationDefinitionId ,
                                             GxSimpleCollection<long> AV9NotificationDefinitionIdCollection ,
                                             int AV9NotificationDefinitionIdCollection_Count ,
                                             string AV8type ,
                                             string AV11searchKey ,
                                             bool A187WWPNotificationIsRead ,
                                             string A112WWPUserExtendedId ,
                                             string AV15Udparg3 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT WWPNotificationShortDescriptio, WWPNotificationTitle, WWPNotificationIsRead, WWPNotificationDefinitionId, WWPUserExtendedId, WWPNotificationId, WWPNotificationIcon, WWPNotificationLink, WWPNotificationMetadata, WWPNotificationCreated FROM WWP_Notification";
         AddWhere(sWhereString, "(WWPUserExtendedId = ( :AV15Udparg3))");
         if ( AV9NotificationDefinitionIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV9NotificationDefinitionIdCollection, "WWPNotificationDefinitionId IN (", ")")+")");
         }
         if ( StringUtil.StrCmp(AV8type, "Read") == 0 )
         {
            AddWhere(sWhereString, "(WWPNotificationIsRead = TRUE)");
         }
         if ( StringUtil.StrCmp(AV8type, "UnRead") == 0 )
         {
            AddWhere(sWhereString, "(WWPNotificationIsRead = FALSE)");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11searchKey)) )
         {
            AddWhere(sWhereString, "(POSITION(RTRIM(:AV11searchKey) IN LOWER(WWPNotificationShortDescriptio)) >= 1 or POSITION(RTRIM(:AV11searchKey) IN LOWER(WWPNotificationTitle)) >= 1)");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPNotificationCreated DESC";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000Q2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000Q2;
          prmP000Q2 = new Object[] {
          new ParDef("AV15Udparg3",GXType.VarChar,100,60) ,
          new ParDef("AV11searchKey",GXType.VarChar,40,0) ,
          new ParDef("AV11searchKey",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Q2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 40);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
                return;
       }
    }

 }

}
