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
   public class prc_sendresidentnotification : GXProcedure
   {
      public prc_sendresidentnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_sendresidentnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_title ,
                           string aP1_message ,
                           string aP2_topic ,
                           SdtSDT_OneSignalCustomData aP3_Metadata ,
                           GxSimpleCollection<Guid> aP4_ResidentIdCollection )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV23topic = aP2_topic;
         this.AV28Metadata = aP3_Metadata;
         this.AV16ResidentIdCollection = aP4_ResidentIdCollection;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_title ,
                                 string aP1_message ,
                                 string aP2_topic ,
                                 SdtSDT_OneSignalCustomData aP3_Metadata ,
                                 GxSimpleCollection<Guid> aP4_ResidentIdCollection )
      {
         this.AV10title = aP0_title;
         this.AV9message = aP1_message;
         this.AV23topic = aP2_topic;
         this.AV28Metadata = aP3_Metadata;
         this.AV16ResidentIdCollection = aP4_ResidentIdCollection;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV23topic, "Toolbox") == 0 )
         {
            AV30isToolboxNotification = true;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10title)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9message)) )
         {
            AV14IsSuccessful = false;
         }
         else
         {
            if ( ! AV30isToolboxNotification )
            {
               AV22Trn_AppNotification = new SdtTrn_AppNotification(context);
               AV22Trn_AppNotification.gxTpr_Appnotificationid = Guid.NewGuid( );
               AV22Trn_AppNotification.gxTpr_Appnotificationdate = DateTimeUtil.Now( context);
               AV22Trn_AppNotification.gxTpr_Appnotificationtitle = AV10title;
               AV22Trn_AppNotification.gxTpr_Appnotificationdescription = AV9message;
               AV22Trn_AppNotification.gxTpr_Appnotificationtopic = AV23topic;
               AV22Trn_AppNotification.gxTpr_Appnotificationmetadata = AV28Metadata.ToJSonString(false, true);
               AV22Trn_AppNotification.Save();
            }
            if ( AV16ResidentIdCollection.Count > 0 )
            {
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    A62ResidentId ,
                                                    AV16ResidentIdCollection } ,
                                                    new int[]{
                                                    }
               });
               /* Using cursor P00932 */
               pr_default.execute(0);
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A62ResidentId = P00932_A62ResidentId[0];
                  A71ResidentGUID = P00932_A71ResidentGUID[0];
                  A599ResidentLanguage = P00932_A599ResidentLanguage[0];
                  A29LocationId = P00932_A29LocationId[0];
                  A11OrganisationId = P00932_A11OrganisationId[0];
                  AV19ResidentGUIDCollection.Add(A71ResidentGUID, 0);
                  if ( ( StringUtil.StrCmp(A599ResidentLanguage, "en") == 0 ) || ( StringUtil.StrCmp(A599ResidentLanguage, "English") == 0 ) )
                  {
                     AV33EnglishResidentGUIDCollection.Add(A71ResidentGUID, 0);
                  }
                  else
                  {
                     AV34DutchResidentGUIDCollection.Add(A71ResidentGUID, 0);
                  }
                  pr_default.readNext(0);
               }
               pr_default.close(0);
            }
            else
            {
               AV39Udparg1 = new prc_getuserlocationid(context).executeUdp( );
               /* Using cursor P00933 */
               pr_default.execute(1, new Object[] {AV39Udparg1});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A29LocationId = P00933_A29LocationId[0];
                  A71ResidentGUID = P00933_A71ResidentGUID[0];
                  A599ResidentLanguage = P00933_A599ResidentLanguage[0];
                  A62ResidentId = P00933_A62ResidentId[0];
                  A11OrganisationId = P00933_A11OrganisationId[0];
                  AV19ResidentGUIDCollection.Add(A71ResidentGUID, 0);
                  if ( ( StringUtil.StrCmp(A599ResidentLanguage, "en") == 0 ) || ( StringUtil.StrCmp(A599ResidentLanguage, "English") == 0 ) )
                  {
                     AV33EnglishResidentGUIDCollection.Add(A71ResidentGUID, 0);
                  }
                  else
                  {
                     AV34DutchResidentGUIDCollection.Add(A71ResidentGUID, 0);
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            if ( AV19ResidentGUIDCollection.Count > 0 )
            {
               if ( AV22Trn_AppNotification.Success() && ! AV30isToolboxNotification )
               {
                  AV40GXV1 = 1;
                  while ( AV40GXV1 <= AV19ResidentGUIDCollection.Count )
                  {
                     AV25ResidentGUIDItem = ((string)AV19ResidentGUIDCollection.Item(AV40GXV1));
                     AV24Trn_ResidentNotification.gxTpr_Appnotificationid = AV22Trn_AppNotification.gxTpr_Appnotificationid;
                     GXt_guid1 = Guid.Empty;
                     new prc_getresidentidfromguid(context ).execute(  AV25ResidentGUIDItem, out  GXt_guid1) ;
                     AV24Trn_ResidentNotification.gxTpr_Residentid = GXt_guid1;
                     AV24Trn_ResidentNotification.gxTpr_Residentnotificationid = Guid.NewGuid( );
                     AV24Trn_ResidentNotification.Insert();
                     AV40GXV1 = (int)(AV40GXV1+1);
                  }
               }
               context.CommitDataStores("prc_sendresidentnotification",pr_default);
               if ( StringUtil.StrCmp(AV10title, "New Filled Form") != 0 )
               {
                  if ( AV33EnglishResidentGUIDCollection.Count > 0 )
                  {
                     pr_default.dynParam(2, new Object[]{ new Object[]{
                                                          A337DeviceUserId ,
                                                          AV33EnglishResidentGUIDCollection } ,
                                                          new int[]{
                                                          }
                     });
                     /* Using cursor P00934 */
                     pr_default.execute(2);
                     while ( (pr_default.getStatus(2) != 101) )
                     {
                        A337DeviceUserId = P00934_A337DeviceUserId[0];
                        A335DeviceToken = P00934_A335DeviceToken[0];
                        A333DeviceId = P00934_A333DeviceId[0];
                        AV27Token = "";
                        if ( AV29SDT_OneSignalRegistration.FromJSonString(A335DeviceToken, null) )
                        {
                           AV27Token = AV29SDT_OneSignalRegistration.gxTpr_Notificationplatformid;
                           if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27Token)) )
                           {
                              AV35EnglishDeviceTokenCollection.Add(AV27Token, 0);
                           }
                        }
                        pr_default.readNext(2);
                     }
                     pr_default.close(2);
                     if ( AV35EnglishDeviceTokenCollection.Count > 0 )
                     {
                        AV30isToolboxNotification = false;
                        new prc_sendonesignalnotification(context ).execute(  AV35EnglishDeviceTokenCollection,  AV10title,  AV9message,  AV28Metadata,  AV30isToolboxNotification, out  AV13OutMessages, out  AV14IsSuccessful) ;
                     }
                  }
                  if ( AV34DutchResidentGUIDCollection.Count > 0 )
                  {
                     pr_default.dynParam(3, new Object[]{ new Object[]{
                                                          A337DeviceUserId ,
                                                          AV34DutchResidentGUIDCollection } ,
                                                          new int[]{
                                                          }
                     });
                     /* Using cursor P00935 */
                     pr_default.execute(3);
                     while ( (pr_default.getStatus(3) != 101) )
                     {
                        A337DeviceUserId = P00935_A337DeviceUserId[0];
                        A335DeviceToken = P00935_A335DeviceToken[0];
                        A333DeviceId = P00935_A333DeviceId[0];
                        AV27Token = "";
                        if ( AV29SDT_OneSignalRegistration.FromJSonString(A335DeviceToken, null) )
                        {
                           AV27Token = AV29SDT_OneSignalRegistration.gxTpr_Notificationplatformid;
                           if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27Token)) )
                           {
                              AV36DutchDeviceTokenCollection.Add(AV27Token, 0);
                           }
                        }
                        pr_default.readNext(3);
                     }
                     pr_default.close(3);
                     if ( AV36DutchDeviceTokenCollection.Count > 0 )
                     {
                        AV30isToolboxNotification = false;
                        if ( StringUtil.StrCmp(AV10title, "New Updates Available") == 0 )
                        {
                           AV31translatedTitle = "Nieuwe updates beschikbaar";
                        }
                        else
                        {
                           AV31translatedTitle = AV10title;
                        }
                        if ( StringUtil.StrCmp(AV9message, "The latest updates have been published and are now live! Open the app to explore the changes") == 0 )
                        {
                           AV32translatedMessage = "De nieuwste updates zijn gepubliceerd en zijn nu live! Open de app om de wijzigingen te bekijken";
                        }
                        else
                        {
                           AV32translatedMessage = AV9message;
                        }
                        new prc_sendonesignalnotification(context ).execute(  AV36DutchDeviceTokenCollection,  AV31translatedTitle,  AV32translatedMessage,  AV28Metadata,  AV30isToolboxNotification, out  AV13OutMessages, out  AV14IsSuccessful) ;
                     }
                  }
               }
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
         AV30isToolboxNotification = false;
         AV22Trn_AppNotification = new SdtTrn_AppNotification(context);
         A62ResidentId = Guid.Empty;
         P00932_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00932_A71ResidentGUID = new string[] {""} ;
         P00932_A599ResidentLanguage = new string[] {""} ;
         P00932_A29LocationId = new Guid[] {Guid.Empty} ;
         P00932_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A599ResidentLanguage = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV19ResidentGUIDCollection = new GxSimpleCollection<string>();
         AV33EnglishResidentGUIDCollection = new GxSimpleCollection<string>();
         AV34DutchResidentGUIDCollection = new GxSimpleCollection<string>();
         AV39Udparg1 = Guid.Empty;
         P00933_A29LocationId = new Guid[] {Guid.Empty} ;
         P00933_A71ResidentGUID = new string[] {""} ;
         P00933_A599ResidentLanguage = new string[] {""} ;
         P00933_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00933_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV25ResidentGUIDItem = "";
         AV24Trn_ResidentNotification = new SdtTrn_ResidentNotification(context);
         GXt_guid1 = Guid.Empty;
         A337DeviceUserId = "";
         P00934_A337DeviceUserId = new string[] {""} ;
         P00934_A335DeviceToken = new string[] {""} ;
         P00934_A333DeviceId = new string[] {""} ;
         A335DeviceToken = "";
         A333DeviceId = "";
         AV27Token = "";
         AV29SDT_OneSignalRegistration = new SdtSDT_OneSignalRegistration(context);
         AV35EnglishDeviceTokenCollection = new GxSimpleCollection<string>();
         AV13OutMessages = "";
         P00935_A337DeviceUserId = new string[] {""} ;
         P00935_A335DeviceToken = new string[] {""} ;
         P00935_A333DeviceId = new string[] {""} ;
         AV36DutchDeviceTokenCollection = new GxSimpleCollection<string>();
         AV31translatedTitle = "";
         AV32translatedMessage = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_sendresidentnotification__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_sendresidentnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_sendresidentnotification__default(),
            new Object[][] {
                new Object[] {
               P00932_A62ResidentId, P00932_A71ResidentGUID, P00932_A599ResidentLanguage, P00932_A29LocationId, P00932_A11OrganisationId
               }
               , new Object[] {
               P00933_A29LocationId, P00933_A71ResidentGUID, P00933_A599ResidentLanguage, P00933_A62ResidentId, P00933_A11OrganisationId
               }
               , new Object[] {
               P00934_A337DeviceUserId, P00934_A335DeviceToken, P00934_A333DeviceId
               }
               , new Object[] {
               P00935_A337DeviceUserId, P00935_A335DeviceToken, P00935_A333DeviceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV40GXV1 ;
      private string A599ResidentLanguage ;
      private string A335DeviceToken ;
      private string A333DeviceId ;
      private string AV27Token ;
      private bool AV30isToolboxNotification ;
      private bool AV14IsSuccessful ;
      private string AV13OutMessages ;
      private string AV10title ;
      private string AV9message ;
      private string AV23topic ;
      private string A71ResidentGUID ;
      private string AV25ResidentGUIDItem ;
      private string A337DeviceUserId ;
      private string AV31translatedTitle ;
      private string AV32translatedMessage ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV39Udparg1 ;
      private Guid GXt_guid1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_OneSignalCustomData AV28Metadata ;
      private GxSimpleCollection<Guid> AV16ResidentIdCollection ;
      private SdtTrn_AppNotification AV22Trn_AppNotification ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00932_A62ResidentId ;
      private string[] P00932_A71ResidentGUID ;
      private string[] P00932_A599ResidentLanguage ;
      private Guid[] P00932_A29LocationId ;
      private Guid[] P00932_A11OrganisationId ;
      private GxSimpleCollection<string> AV19ResidentGUIDCollection ;
      private GxSimpleCollection<string> AV33EnglishResidentGUIDCollection ;
      private GxSimpleCollection<string> AV34DutchResidentGUIDCollection ;
      private Guid[] P00933_A29LocationId ;
      private string[] P00933_A71ResidentGUID ;
      private string[] P00933_A599ResidentLanguage ;
      private Guid[] P00933_A62ResidentId ;
      private Guid[] P00933_A11OrganisationId ;
      private SdtTrn_ResidentNotification AV24Trn_ResidentNotification ;
      private string[] P00934_A337DeviceUserId ;
      private string[] P00934_A335DeviceToken ;
      private string[] P00934_A333DeviceId ;
      private SdtSDT_OneSignalRegistration AV29SDT_OneSignalRegistration ;
      private GxSimpleCollection<string> AV35EnglishDeviceTokenCollection ;
      private string[] P00935_A337DeviceUserId ;
      private string[] P00935_A335DeviceToken ;
      private string[] P00935_A333DeviceId ;
      private GxSimpleCollection<string> AV36DutchDeviceTokenCollection ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_sendresidentnotification__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class prc_sendresidentnotification__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class prc_sendresidentnotification__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_P00932( IGxContext context ,
                                          Guid A62ResidentId ,
                                          GxSimpleCollection<Guid> AV16ResidentIdCollection )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      Object[] GXv_Object2 = new Object[2];
      scmdbuf = "SELECT ResidentId, ResidentGUID, ResidentLanguage, LocationId, OrganisationId FROM Trn_Resident";
      AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV16ResidentIdCollection, "ResidentId IN (", ")")+")");
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY ResidentId, LocationId, OrganisationId";
      GXv_Object2[0] = scmdbuf;
      return GXv_Object2 ;
   }

   protected Object[] conditional_P00934( IGxContext context ,
                                          string A337DeviceUserId ,
                                          GxSimpleCollection<string> AV33EnglishResidentGUIDCollection )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      Object[] GXv_Object4 = new Object[2];
      scmdbuf = "SELECT DeviceUserId, DeviceToken, DeviceId FROM Trn_Device";
      AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV33EnglishResidentGUIDCollection, "DeviceUserId IN (", ")")+")");
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY DeviceId";
      GXv_Object4[0] = scmdbuf;
      return GXv_Object4 ;
   }

   protected Object[] conditional_P00935( IGxContext context ,
                                          string A337DeviceUserId ,
                                          GxSimpleCollection<string> AV34DutchResidentGUIDCollection )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      Object[] GXv_Object6 = new Object[2];
      scmdbuf = "SELECT DeviceUserId, DeviceToken, DeviceId FROM Trn_Device";
      AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV34DutchResidentGUIDCollection, "DeviceUserId IN (", ")")+")");
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY DeviceId";
      GXv_Object6[0] = scmdbuf;
      return GXv_Object6 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 0 :
                  return conditional_P00932(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] );
            case 2 :
                  return conditional_P00934(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] );
            case 3 :
                  return conditional_P00935(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00933;
       prmP00933 = new Object[] {
       new ParDef("AV39Udparg1",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00932;
       prmP00932 = new Object[] {
       };
       Object[] prmP00934;
       prmP00934 = new Object[] {
       };
       Object[] prmP00935;
       prmP00935 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("P00932", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00932,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P00933", "SELECT LocationId, ResidentGUID, ResidentLanguage, ResidentId, OrganisationId FROM Trn_Resident WHERE LocationId = :AV39Udparg1 ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00933,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P00934", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00934,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P00935", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00935,100, GxCacheFrequency.OFF ,false,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 1000);
             ((string[]) buf[2])[0] = rslt.getString(3, 128);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 1000);
             ((string[]) buf[2])[0] = rslt.getString(3, 128);
             return;
    }
 }

}

}
