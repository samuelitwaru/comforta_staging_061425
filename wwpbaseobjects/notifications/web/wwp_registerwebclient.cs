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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_registerwebclient : GXProcedure
   {
      public wwp_registerwebclient( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_registerwebclient( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ClientId ,
                           short aP1_BrowserId ,
                           string aP2_BrowserVersion ,
                           string aP3_UserGUID )
      {
         this.AV13ClientId = aP0_ClientId;
         this.AV11BrowserId = aP1_BrowserId;
         this.AV12BrowserVersion = aP2_BrowserVersion;
         this.AV15UserGUID = aP3_UserGUID;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_ClientId ,
                                 short aP1_BrowserId ,
                                 string aP2_BrowserVersion ,
                                 string aP3_UserGUID )
      {
         this.AV13ClientId = aP0_ClientId;
         this.AV11BrowserId = aP1_BrowserId;
         this.AV12BrowserVersion = aP2_BrowserVersion;
         this.AV15UserGUID = aP3_UserGUID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV16Pgmname,  "Begin Web Client Registration") ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15UserGUID)) )
         {
            GXt_char1 = AV15UserGUID;
            new uwwp_getloggeduserid(context ).execute( out  GXt_char1) ;
            AV15UserGUID = GXt_char1;
         }
         if ( ! new GeneXus.Programs.wwpbaseobjects.wwp_existsuserextended(context).executeUdp(  AV15UserGUID) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV16Pgmname,  StringUtil.Format( "Creating User Extended %1...", AV15UserGUID, "", "", "", "", "", "", "", "")) ;
            AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbyguid(AV15UserGUID, out  AV8GAMErrorCollection);
            new GeneXus.Programs.wwpbaseobjects.wwp_usersync(context ).execute(  "INS",  AV9GAMUser, out  AV10Messages) ;
         }
         AV17GXLvl10 = 0;
         /* Using cursor P003F2 */
         pr_default.execute(0, new Object[] {AV13ClientId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A153WWPWebClientId = P003F2_A153WWPWebClientId[0];
            A154WWPWebClientBrowserId = P003F2_A154WWPWebClientBrowserId[0];
            A155WWPWebClientBrowserVersion = P003F2_A155WWPWebClientBrowserVersion[0];
            A157WWPWebClientLastRegistered = P003F2_A157WWPWebClientLastRegistered[0];
            A112WWPUserExtendedId = P003F2_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = P003F2_n112WWPUserExtendedId[0];
            AV17GXLvl10 = 1;
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV16Pgmname,  "Updating Web Client") ;
            A154WWPWebClientBrowserId = AV11BrowserId;
            A155WWPWebClientBrowserVersion = AV12BrowserVersion;
            A157WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A112WWPUserExtendedId = AV15UserGUID;
            n112WWPUserExtendedId = false;
            /* Using cursor P003F3 */
            pr_default.execute(1, new Object[] {A154WWPWebClientBrowserId, A155WWPWebClientBrowserVersion, A157WWPWebClientLastRegistered, n112WWPUserExtendedId, A112WWPUserExtendedId, A153WWPWebClientId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV17GXLvl10 == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV16Pgmname,  "Creating Web Client") ;
            /*
               INSERT RECORD ON TABLE WWP_WebClient

            */
            A153WWPWebClientId = AV13ClientId;
            A154WWPWebClientBrowserId = AV11BrowserId;
            A155WWPWebClientBrowserVersion = AV12BrowserVersion;
            A156WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A157WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            A112WWPUserExtendedId = AV15UserGUID;
            n112WWPUserExtendedId = false;
            /* Using cursor P003F4 */
            pr_default.execute(2, new Object[] {A153WWPWebClientId, A154WWPWebClientBrowserId, A155WWPWebClientBrowserVersion, A156WWPWebClientFirstRegistered, A157WWPWebClientLastRegistered, n112WWPUserExtendedId, A112WWPUserExtendedId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
            if ( (pr_default.getStatus(2) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_debug(  AV16Pgmname,  "Completed Web Client Registration") ;
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_registerwebclient",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV16Pgmname = "";
         GXt_char1 = "";
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         P003F2_A153WWPWebClientId = new string[] {""} ;
         P003F2_A154WWPWebClientBrowserId = new short[1] ;
         P003F2_A155WWPWebClientBrowserVersion = new string[] {""} ;
         P003F2_A157WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         P003F2_A112WWPUserExtendedId = new string[] {""} ;
         P003F2_n112WWPUserExtendedId = new bool[] {false} ;
         A153WWPWebClientId = "";
         A155WWPWebClientBrowserVersion = "";
         A157WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         A112WWPUserExtendedId = "";
         A156WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_registerwebclient__default(),
            new Object[][] {
                new Object[] {
               P003F2_A153WWPWebClientId, P003F2_A154WWPWebClientBrowserId, P003F2_A155WWPWebClientBrowserVersion, P003F2_A157WWPWebClientLastRegistered, P003F2_A112WWPUserExtendedId, P003F2_n112WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         AV16Pgmname = "WWPBaseObjects.Notifications.Web.WWP_RegisterWebClient";
         /* GeneXus formulas. */
         AV16Pgmname = "WWPBaseObjects.Notifications.Web.WWP_RegisterWebClient";
      }

      private short AV11BrowserId ;
      private short AV17GXLvl10 ;
      private short A154WWPWebClientBrowserId ;
      private int GX_INS32 ;
      private string AV13ClientId ;
      private string AV15UserGUID ;
      private string AV16Pgmname ;
      private string GXt_char1 ;
      private string A153WWPWebClientId ;
      private string A112WWPUserExtendedId ;
      private string Gx_emsg ;
      private DateTime A157WWPWebClientLastRegistered ;
      private DateTime A156WWPWebClientFirstRegistered ;
      private bool n112WWPUserExtendedId ;
      private string AV12BrowserVersion ;
      private string A155WWPWebClientBrowserVersion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV8GAMErrorCollection ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private IDataStoreProvider pr_default ;
      private string[] P003F2_A153WWPWebClientId ;
      private short[] P003F2_A154WWPWebClientBrowserId ;
      private string[] P003F2_A155WWPWebClientBrowserVersion ;
      private DateTime[] P003F2_A157WWPWebClientLastRegistered ;
      private string[] P003F2_A112WWPUserExtendedId ;
      private bool[] P003F2_n112WWPUserExtendedId ;
   }

   public class wwp_registerwebclient__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003F2;
          prmP003F2 = new Object[] {
          new ParDef("AV13ClientId",GXType.Char,100,0)
          };
          Object[] prmP003F3;
          prmP003F3 = new Object[] {
          new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
          new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
          new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
          new ParDef("WWPWebClientId",GXType.Char,100,0)
          };
          Object[] prmP003F4;
          prmP003F4 = new Object[] {
          new ParDef("WWPWebClientId",GXType.Char,100,0) ,
          new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
          new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
          new ParDef("WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
          new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
          new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P003F2", "SELECT WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientLastRegistered, WWPUserExtendedId FROM WWP_WebClient WHERE WWPWebClientId = ( :AV13ClientId) ORDER BY WWPWebClientId  FOR UPDATE OF WWP_WebClient",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003F2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P003F3", "SAVEPOINT gxupdate;UPDATE WWP_WebClient SET WWPWebClientBrowserId=:WWPWebClientBrowserId, WWPWebClientBrowserVersion=:WWPWebClientBrowserVersion, WWPWebClientLastRegistered=:WWPWebClientLastRegistered, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPWebClientId = :WWPWebClientId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003F3)
             ,new CursorDef("P003F4", "SAVEPOINT gxupdate;INSERT INTO WWP_WebClient(WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId) VALUES(:WWPWebClientId, :WWPWebClientBrowserId, :WWPWebClientBrowserVersion, :WWPWebClientFirstRegistered, :WWPWebClientLastRegistered, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP003F4)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
                ((string[]) buf[4])[0] = rslt.getString(5, 40);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
