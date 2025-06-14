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
   public class prc_sendnotification : GXProcedure
   {
      public prc_sendnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_sendnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_title ,
                           string aP1_message ,
                           string aP2_ResidentId ,
                           out string aP3_response )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV29ResidentId = aP2_ResidentId;
         this.AV8response = "" ;
         initialize();
         ExecuteImpl();
         aP3_response=this.AV8response;
      }

      public string executeUdp( string aP0_title ,
                                string aP1_message ,
                                string aP2_ResidentId )
      {
         execute(aP0_title, aP1_message, aP2_ResidentId, out aP3_response);
         return AV8response ;
      }

      public void executeSubmit( string aP0_title ,
                                 string aP1_message ,
                                 string aP2_ResidentId ,
                                 out string aP3_response )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV29ResidentId = aP2_ResidentId;
         this.AV8response = "" ;
         SubmitImpl();
         aP3_response=this.AV8response;
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
            /* Using cursor P00792 */
            pr_default.execute(0, new Object[] {AV29ResidentId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A337DeviceUserId = P00792_A337DeviceUserId[0];
               A335DeviceToken = P00792_A335DeviceToken[0];
               A333DeviceId = P00792_A333DeviceId[0];
               AV26Token = "";
               if ( AV25SDT_OneSignalRegistration.FromJSonString(A335DeviceToken, null) )
               {
                  AV26Token = AV25SDT_OneSignalRegistration.gxTpr_Notificationplatformid;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26Token)) )
                  {
                     AV24DeviceTokenCollection.Add(AV26Token, 0);
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV24DeviceTokenCollection.Count > 0 )
            {
               AV27Metadata = new SdtSDT_OneSignalCustomData(context);
               AV27Metadata.gxTpr_Notificationcategory = "General";
               new prc_sendonesignalnotification(context ).execute(  AV24DeviceTokenCollection,  AV10title,  AV9message,  AV27Metadata,  false, out  AV13OutMessages, out  AV14IsSuccessful) ;
            }
            if ( AV14IsSuccessful )
            {
               AV8response = "Notification sent successfully";
            }
            else
            {
               AV8response = "Notification could not be sent " + AV13OutMessages;
            }
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
         AV8response = "";
         P00792_A337DeviceUserId = new string[] {""} ;
         P00792_A335DeviceToken = new string[] {""} ;
         P00792_A333DeviceId = new string[] {""} ;
         A337DeviceUserId = "";
         A335DeviceToken = "";
         A333DeviceId = "";
         AV26Token = "";
         AV25SDT_OneSignalRegistration = new SdtSDT_OneSignalRegistration(context);
         AV24DeviceTokenCollection = new GxSimpleCollection<string>();
         AV27Metadata = new SdtSDT_OneSignalCustomData(context);
         AV13OutMessages = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_sendnotification__default(),
            new Object[][] {
                new Object[] {
               P00792_A337DeviceUserId, P00792_A335DeviceToken, P00792_A333DeviceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A335DeviceToken ;
      private string A333DeviceId ;
      private string AV26Token ;
      private bool AV14IsSuccessful ;
      private string AV8response ;
      private string AV13OutMessages ;
      private string AV10title ;
      private string AV9message ;
      private string AV29ResidentId ;
      private string A337DeviceUserId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00792_A337DeviceUserId ;
      private string[] P00792_A335DeviceToken ;
      private string[] P00792_A333DeviceId ;
      private SdtSDT_OneSignalRegistration AV25SDT_OneSignalRegistration ;
      private GxSimpleCollection<string> AV24DeviceTokenCollection ;
      private SdtSDT_OneSignalCustomData AV27Metadata ;
      private string aP3_response ;
   }

   public class prc_sendnotification__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00792;
          prmP00792 = new Object[] {
          new ParDef("AV29ResidentId",GXType.VarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P00792", "SELECT DeviceUserId, DeviceToken, DeviceId FROM Trn_Device WHERE DeviceUserId = ( :AV29ResidentId) ORDER BY DeviceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00792,100, GxCacheFrequency.OFF ,false,false )
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
