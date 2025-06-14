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
   public class prc_sendresidentdiscussionnotification : GXProcedure
   {
      public prc_sendresidentdiscussionnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_sendresidentdiscussionnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_title ,
                           string aP1_message ,
                           string aP2_ResidentGUID ,
                           SdtSDT_OneSignalCustomData aP3_Metadata )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV18ResidentGUID = aP2_ResidentGUID;
         this.AV28Metadata = aP3_Metadata;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_title ,
                                 string aP1_message ,
                                 string aP2_ResidentGUID ,
                                 SdtSDT_OneSignalCustomData aP3_Metadata )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV18ResidentGUID = aP2_ResidentGUID;
         this.AV28Metadata = aP3_Metadata;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10title)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9message)) )
         {
            AV14IsSuccessful = false;
         }
         else
         {
            /* Using cursor P009P2 */
            pr_default.execute(0, new Object[] {AV18ResidentGUID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A337DeviceUserId = P009P2_A337DeviceUserId[0];
               A335DeviceToken = P009P2_A335DeviceToken[0];
               A333DeviceId = P009P2_A333DeviceId[0];
               AV27Token = "";
               if ( AV26SDT_OneSignalRegistration.FromJSonString(A335DeviceToken, null) )
               {
                  AV27Token = AV26SDT_OneSignalRegistration.gxTpr_Notificationplatformid;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27Token)) )
                  {
                     AV20DeviceTokenCollection.Add(AV27Token, 0);
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            new prc_sendonesignalnotification(context ).execute(  AV20DeviceTokenCollection,  AV10title,  AV9message,  AV28Metadata,  false, out  AV13OutMessages, out  AV14IsSuccessful) ;
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
         P009P2_A337DeviceUserId = new string[] {""} ;
         P009P2_A335DeviceToken = new string[] {""} ;
         P009P2_A333DeviceId = new string[] {""} ;
         A337DeviceUserId = "";
         A335DeviceToken = "";
         A333DeviceId = "";
         AV27Token = "";
         AV26SDT_OneSignalRegistration = new SdtSDT_OneSignalRegistration(context);
         AV20DeviceTokenCollection = new GxSimpleCollection<string>();
         AV13OutMessages = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_sendresidentdiscussionnotification__default(),
            new Object[][] {
                new Object[] {
               P009P2_A337DeviceUserId, P009P2_A335DeviceToken, P009P2_A333DeviceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A335DeviceToken ;
      private string A333DeviceId ;
      private string AV27Token ;
      private bool AV14IsSuccessful ;
      private string AV13OutMessages ;
      private string AV10title ;
      private string AV9message ;
      private string AV18ResidentGUID ;
      private string A337DeviceUserId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_OneSignalCustomData AV28Metadata ;
      private IDataStoreProvider pr_default ;
      private string[] P009P2_A337DeviceUserId ;
      private string[] P009P2_A335DeviceToken ;
      private string[] P009P2_A333DeviceId ;
      private SdtSDT_OneSignalRegistration AV26SDT_OneSignalRegistration ;
      private GxSimpleCollection<string> AV20DeviceTokenCollection ;
   }

   public class prc_sendresidentdiscussionnotification__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009P2;
          prmP009P2 = new Object[] {
          new ParDef("AV18ResidentGUID",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P009P2", "SELECT DeviceUserId, DeviceToken, DeviceId FROM Trn_Device WHERE DeviceUserId = ( RTRIM(LTRIM(:AV18ResidentGUID))) ORDER BY DeviceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009P2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1000);
                ((string[]) buf[2])[0] = rslt.getString(3, 128);
                return;
       }
    }

 }

}
