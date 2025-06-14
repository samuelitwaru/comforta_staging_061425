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
   public class prc_registermobiledevice : GXProcedure
   {
      public prc_registermobiledevice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_registermobiledevice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DeviceToken ,
                           string aP1_DeviceId ,
                           short aP2_DeviceType ,
                           string aP3_NotificationPlatform ,
                           string aP4_NotificationPlatformId ,
                           string aP5_UserId ,
                           out string aP6_Message )
      {
         this.AV9DeviceToken = aP0_DeviceToken;
         this.AV8DeviceId = aP1_DeviceId;
         this.AV10DeviceType = aP2_DeviceType;
         this.AV12NotificationPlatform = aP3_NotificationPlatform;
         this.AV13NotificationPlatformId = aP4_NotificationPlatformId;
         this.AV14UserId = aP5_UserId;
         this.AV11Message = "" ;
         initialize();
         ExecuteImpl();
         aP6_Message=this.AV11Message;
      }

      public string executeUdp( string aP0_DeviceToken ,
                                string aP1_DeviceId ,
                                short aP2_DeviceType ,
                                string aP3_NotificationPlatform ,
                                string aP4_NotificationPlatformId ,
                                string aP5_UserId )
      {
         execute(aP0_DeviceToken, aP1_DeviceId, aP2_DeviceType, aP3_NotificationPlatform, aP4_NotificationPlatformId, aP5_UserId, out aP6_Message);
         return AV11Message ;
      }

      public void executeSubmit( string aP0_DeviceToken ,
                                 string aP1_DeviceId ,
                                 short aP2_DeviceType ,
                                 string aP3_NotificationPlatform ,
                                 string aP4_NotificationPlatformId ,
                                 string aP5_UserId ,
                                 out string aP6_Message )
      {
         this.AV9DeviceToken = aP0_DeviceToken;
         this.AV8DeviceId = aP1_DeviceId;
         this.AV10DeviceType = aP2_DeviceType;
         this.AV12NotificationPlatform = aP3_NotificationPlatform;
         this.AV13NotificationPlatformId = aP4_NotificationPlatformId;
         this.AV14UserId = aP5_UserId;
         this.AV11Message = "" ;
         SubmitImpl();
         aP6_Message=this.AV11Message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16SDT_OneSignalRegistration = new SdtSDT_OneSignalRegistration(context);
         AV16SDT_OneSignalRegistration.gxTpr_Deviceid = AV8DeviceId;
         AV16SDT_OneSignalRegistration.gxTpr_Devicetoken = AV9DeviceToken;
         AV16SDT_OneSignalRegistration.gxTpr_Devicetype = (decimal)(AV10DeviceType);
         AV16SDT_OneSignalRegistration.gxTpr_Notificationplatform = AV12NotificationPlatform;
         AV16SDT_OneSignalRegistration.gxTpr_Notificationplatformid = AV13NotificationPlatformId;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9DeviceToken)) || String.IsNullOrEmpty(StringUtil.RTrim( AV8DeviceId)) )
         {
            AV11Message = "Device could not be registered";
         }
         else
         {
            AV17GXLvl13 = 0;
            /* Using cursor P00782 */
            pr_default.execute(0, new Object[] {AV10DeviceType, AV8DeviceId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A333DeviceId = P00782_A333DeviceId[0];
               A334DeviceType = P00782_A334DeviceType[0];
               A335DeviceToken = P00782_A335DeviceToken[0];
               A336DeviceName = P00782_A336DeviceName[0];
               A337DeviceUserId = P00782_A337DeviceUserId[0];
               AV17GXLvl13 = 1;
               A335DeviceToken = AV16SDT_OneSignalRegistration.ToJSonString(false, true);
               A336DeviceName = AV8DeviceId;
               A337DeviceUserId = AV14UserId;
               /* Using cursor P00783 */
               pr_default.execute(1, new Object[] {A335DeviceToken, A336DeviceName, A337DeviceUserId, A333DeviceId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV17GXLvl13 == 0 )
            {
               /*
                  INSERT RECORD ON TABLE Trn_Device

               */
               A334DeviceType = AV10DeviceType;
               A333DeviceId = AV8DeviceId;
               A335DeviceToken = AV16SDT_OneSignalRegistration.ToJSonString(false, true);
               A336DeviceName = AV8DeviceId;
               A337DeviceUserId = AV14UserId;
               /* Using cursor P00784 */
               pr_default.execute(2, new Object[] {A333DeviceId, A334DeviceType, A335DeviceToken, A336DeviceName, A337DeviceUserId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
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
            AV11Message = "Device registered successfully";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_registermobiledevice",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11Message = "";
         AV16SDT_OneSignalRegistration = new SdtSDT_OneSignalRegistration(context);
         P00782_A333DeviceId = new string[] {""} ;
         P00782_A334DeviceType = new short[1] ;
         P00782_A335DeviceToken = new string[] {""} ;
         P00782_A336DeviceName = new string[] {""} ;
         P00782_A337DeviceUserId = new string[] {""} ;
         A333DeviceId = "";
         A335DeviceToken = "";
         A336DeviceName = "";
         A337DeviceUserId = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_registermobiledevice__default(),
            new Object[][] {
                new Object[] {
               P00782_A333DeviceId, P00782_A334DeviceType, P00782_A335DeviceToken, P00782_A336DeviceName, P00782_A337DeviceUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10DeviceType ;
      private short AV17GXLvl13 ;
      private short A334DeviceType ;
      private int GX_INS67 ;
      private string AV9DeviceToken ;
      private string AV8DeviceId ;
      private string A333DeviceId ;
      private string A335DeviceToken ;
      private string A336DeviceName ;
      private string Gx_emsg ;
      private string AV11Message ;
      private string AV12NotificationPlatform ;
      private string AV13NotificationPlatformId ;
      private string AV14UserId ;
      private string A337DeviceUserId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_OneSignalRegistration AV16SDT_OneSignalRegistration ;
      private IDataStoreProvider pr_default ;
      private string[] P00782_A333DeviceId ;
      private short[] P00782_A334DeviceType ;
      private string[] P00782_A335DeviceToken ;
      private string[] P00782_A336DeviceName ;
      private string[] P00782_A337DeviceUserId ;
      private string aP6_Message ;
   }

   public class prc_registermobiledevice__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00782;
          prmP00782 = new Object[] {
          new ParDef("AV10DeviceType",GXType.Int16,1,0) ,
          new ParDef("AV8DeviceId",GXType.Char,128,0)
          };
          Object[] prmP00783;
          prmP00783 = new Object[] {
          new ParDef("DeviceToken",GXType.Char,1000,0) ,
          new ParDef("DeviceName",GXType.Char,128,0) ,
          new ParDef("DeviceUserId",GXType.VarChar,100,60) ,
          new ParDef("DeviceId",GXType.Char,128,0)
          };
          Object[] prmP00784;
          prmP00784 = new Object[] {
          new ParDef("DeviceId",GXType.Char,128,0) ,
          new ParDef("DeviceType",GXType.Int16,1,0) ,
          new ParDef("DeviceToken",GXType.Char,1000,0) ,
          new ParDef("DeviceName",GXType.Char,128,0) ,
          new ParDef("DeviceUserId",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P00782", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId FROM Trn_Device WHERE DeviceType = :AV10DeviceType and DeviceId = ( :AV8DeviceId) ORDER BY DeviceType, DeviceId  FOR UPDATE OF Trn_Device",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00782,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00783", "SAVEPOINT gxupdate;UPDATE Trn_Device SET DeviceToken=:DeviceToken, DeviceName=:DeviceName, DeviceUserId=:DeviceUserId  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00783)
             ,new CursorDef("P00784", "SAVEPOINT gxupdate;INSERT INTO Trn_Device(DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId) VALUES(:DeviceId, :DeviceType, :DeviceToken, :DeviceName, :DeviceUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00784)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 128);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1000);
                ((string[]) buf[3])[0] = rslt.getString(4, 128);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
