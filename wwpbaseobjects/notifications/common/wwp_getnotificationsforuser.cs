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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_getnotificationsforuser : GXProcedure
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
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public wwp_getnotificationsforuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getnotificationsforuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "Comforta_version21") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Udparg3 = new uwwp_getloggeduserid(context).executeUdp( );
         /* Using cursor P00092 */
         pr_default.execute(0, new Object[] {AV9Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A187WWPNotificationIsRead = P00092_A187WWPNotificationIsRead[0];
            A112WWPUserExtendedId = P00092_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = P00092_n112WWPUserExtendedId[0];
            A127WWPNotificationId = P00092_A127WWPNotificationId[0];
            A181WWPNotificationIcon = P00092_A181WWPNotificationIcon[0];
            A182WWPNotificationTitle = P00092_A182WWPNotificationTitle[0];
            A183WWPNotificationShortDescriptio = P00092_A183WWPNotificationShortDescriptio[0];
            A184WWPNotificationLink = P00092_A184WWPNotificationLink[0];
            A129WWPNotificationCreated = P00092_A129WWPNotificationCreated[0];
            Gxm1wwp_sdtnotificationsdata = new WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
            Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdata, 0);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationid = (int)(A127WWPNotificationId);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationiconclass = "NotificationFontIcon"+" "+A181WWPNotificationIcon;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationtitle = A182WWPNotificationTitle;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdescription = A183WWPNotificationShortDescriptio;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdatetime = A129WWPNotificationCreated;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationlink = A184WWPNotificationLink;
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
         AV9Udparg3 = "";
         P00092_A187WWPNotificationIsRead = new bool[] {false} ;
         P00092_A112WWPUserExtendedId = new string[] {""} ;
         P00092_n112WWPUserExtendedId = new bool[] {false} ;
         P00092_A127WWPNotificationId = new long[1] ;
         P00092_A181WWPNotificationIcon = new string[] {""} ;
         P00092_A182WWPNotificationTitle = new string[] {""} ;
         P00092_A183WWPNotificationShortDescriptio = new string[] {""} ;
         P00092_A184WWPNotificationLink = new string[] {""} ;
         P00092_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         A112WWPUserExtendedId = "";
         A181WWPNotificationIcon = "";
         A182WWPNotificationTitle = "";
         A183WWPNotificationShortDescriptio = "";
         A184WWPNotificationLink = "";
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Gxm1wwp_sdtnotificationsdata = new WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_getnotificationsforuser__default(),
            new Object[][] {
                new Object[] {
               P00092_A187WWPNotificationIsRead, P00092_A112WWPUserExtendedId, P00092_n112WWPUserExtendedId, P00092_A127WWPNotificationId, P00092_A181WWPNotificationIcon, P00092_A182WWPNotificationTitle, P00092_A183WWPNotificationShortDescriptio, P00092_A184WWPNotificationLink, P00092_A129WWPNotificationCreated
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A127WWPNotificationId ;
      private string AV9Udparg3 ;
      private string A112WWPUserExtendedId ;
      private DateTime A129WWPNotificationCreated ;
      private bool A187WWPNotificationIsRead ;
      private bool n112WWPUserExtendedId ;
      private string A181WWPNotificationIcon ;
      private string A182WWPNotificationTitle ;
      private string A183WWPNotificationShortDescriptio ;
      private string A184WWPNotificationLink ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private bool[] P00092_A187WWPNotificationIsRead ;
      private string[] P00092_A112WWPUserExtendedId ;
      private bool[] P00092_n112WWPUserExtendedId ;
      private long[] P00092_A127WWPNotificationId ;
      private string[] P00092_A181WWPNotificationIcon ;
      private string[] P00092_A182WWPNotificationTitle ;
      private string[] P00092_A183WWPNotificationShortDescriptio ;
      private string[] P00092_A184WWPNotificationLink ;
      private DateTime[] P00092_A129WWPNotificationCreated ;
      private WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem Gxm1wwp_sdtnotificationsdata ;
      private GXBaseCollection<WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol ;
   }

   public class wwp_getnotificationsforuser__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00092;
          prmP00092 = new Object[] {
          new ParDef("AV9Udparg3",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00092", "SELECT WWPNotificationIsRead, WWPUserExtendedId, WWPNotificationId, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationCreated FROM WWP_Notification WHERE (Not WWPNotificationIsRead) AND (WWPUserExtendedId = ( :AV9Udparg3)) ORDER BY WWPNotificationCreated DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00092,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
                return;
       }
    }

 }

}
