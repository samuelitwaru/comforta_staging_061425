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
namespace GeneXus.Programs.wwpbaseobjects {
   public class audittransaction : GXProcedure
   {
      public audittransaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public audittransaction( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( WorkWithPlus.workwithplus_web.SdtAuditingObject aP0_AuditingObject ,
                           string aP1_CallerName )
      {
         this.AV8AuditingObject = aP0_AuditingObject;
         this.AV11CallerName = aP1_CallerName;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( WorkWithPlus.workwithplus_web.SdtAuditingObject aP0_AuditingObject ,
                                 string aP1_CallerName )
      {
         this.AV8AuditingObject = aP0_AuditingObject;
         this.AV11CallerName = aP1_CallerName;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV13WWPContext) ;
         AV16AuditPrimaryKey = "";
         AV18FirstRecord = true;
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV8AuditingObject.gxTpr_Record.Count )
         {
            AV9AuditingObjectRecordItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem)AV8AuditingObject.gxTpr_Record.Item(AV19GXV1));
            AV12Audit = new SdtTrn_Audit(context);
            AV12Audit.gxTpr_Auditdate = DateTimeUtil.Now( context);
            AV12Audit.gxTpr_Gamuserid = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            AV12Audit.gxTpr_Audittablename = AV9AuditingObjectRecordItem.gxTpr_Tablename;
            GXt_char1 = "";
            new prc_getloggedinusername(context ).execute( out  GXt_char1) ;
            AV12Audit.gxTpr_Auditusername = GXt_char1;
            GXt_guid2 = Guid.Empty;
            new prc_getuserorganisationid(context ).execute( out  GXt_guid2) ;
            AV12Audit.gxTpr_Organisationid = GXt_guid2;
            if ( AV18FirstRecord )
            {
               AV14AuditShortDescription = context.GetMessage( "Record '", "");
               AV15AuditDescription = context.GetMessage( "Record with key '", "");
               AV17ActualMode = AV8AuditingObject.gxTpr_Mode;
            }
            else
            {
               AV14AuditShortDescription = AV16AuditPrimaryKey;
               AV15AuditDescription = AV16AuditPrimaryKey;
               AV17ActualMode = AV9AuditingObjectRecordItem.gxTpr_Mode;
            }
            if ( StringUtil.StrCmp(AV17ActualMode, "INS") == 0 )
            {
               AV12Audit.gxTpr_Auditaction = context.GetMessage( "Insert", "");
            }
            else if ( StringUtil.StrCmp(AV17ActualMode, "UPD") == 0 )
            {
               AV12Audit.gxTpr_Auditaction = context.GetMessage( "Update", "");
            }
            else if ( StringUtil.StrCmp(AV17ActualMode, "DLT") == 0 )
            {
               AV12Audit.gxTpr_Auditaction = context.GetMessage( "Delete", "");
            }
            AV20GXV2 = 1;
            while ( AV20GXV2 <= AV9AuditingObjectRecordItem.gxTpr_Attribute.Count )
            {
               AV10AuditingObjectRecordItemAttributeItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem)AV9AuditingObjectRecordItem.gxTpr_Attribute.Item(AV20GXV2));
               if ( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey )
               {
                  if ( StringUtil.StrCmp(AV17ActualMode, "INS") == 0 )
                  {
                     AV15AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " ";
                  }
                  else
                  {
                     AV15AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + " ";
                  }
               }
               if ( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute )
               {
                  if ( StringUtil.StrCmp(AV17ActualMode, "INS") == 0 )
                  {
                     AV14AuditShortDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " ";
                     AV15AuditDescription += "- " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + " ";
                  }
                  else
                  {
                     AV14AuditShortDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + " ";
                     AV15AuditDescription += "- " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + " ";
                  }
               }
               AV20GXV2 = (int)(AV20GXV2+1);
            }
            if ( AV18FirstRecord )
            {
               AV18FirstRecord = false;
               AV16AuditPrimaryKey = AV14AuditShortDescription;
            }
            AV14AuditShortDescription += context.GetMessage( "' was ", "");
            AV15AuditDescription += context.GetMessage( "' was ", "");
            if ( StringUtil.StrCmp(AV17ActualMode, "INS") == 0 )
            {
               AV14AuditShortDescription += context.GetMessage( "inserted", "");
               AV15AuditDescription += context.GetMessage( "inserted.", "") + StringUtil.NewLine( ) + context.GetMessage( " Attributes:", "") + StringUtil.NewLine( );
            }
            else if ( StringUtil.StrCmp(AV17ActualMode, "UPD") == 0 )
            {
               AV14AuditShortDescription += context.GetMessage( "updated", "");
               AV15AuditDescription += context.GetMessage( "updated.", "") + StringUtil.NewLine( ) + context.GetMessage( " Modified attributes:", "") + StringUtil.NewLine( );
            }
            else if ( StringUtil.StrCmp(AV17ActualMode, "DLT") == 0 )
            {
               AV14AuditShortDescription += context.GetMessage( "deleted", "");
               AV15AuditDescription += context.GetMessage( "deleted.", "") + StringUtil.NewLine( ) + context.GetMessage( " Attributes:", "") + StringUtil.NewLine( );
            }
            AV14AuditShortDescription += ".";
            AV21GXV3 = 1;
            while ( AV21GXV3 <= AV9AuditingObjectRecordItem.gxTpr_Attribute.Count )
            {
               AV10AuditingObjectRecordItemAttributeItem = ((WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem)AV9AuditingObjectRecordItem.gxTpr_Attribute.Item(AV21GXV3));
               if ( ! ( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey ) )
               {
                  if ( StringUtil.StrCmp(AV17ActualMode, "INS") == 0 )
                  {
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue)) )
                     {
                        AV15AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + StringUtil.NewLine( );
                     }
                  }
                  else if ( StringUtil.StrCmp(AV17ActualMode, "UPD") == 0 )
                  {
                     if ( StringUtil.StrCmp(AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue, AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue) != 0 )
                     {
                        AV15AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue + context.GetMessage( " (Old value = ", "") + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + ")" + StringUtil.NewLine( );
                     }
                  }
                  else if ( StringUtil.StrCmp(AV17ActualMode, "DLT") == 0 )
                  {
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue)) ) )
                     {
                        AV15AuditDescription += AV10AuditingObjectRecordItemAttributeItem.gxTpr_Description + " = " + AV10AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue + StringUtil.NewLine( );
                     }
                  }
               }
               AV21GXV3 = (int)(AV21GXV3+1);
            }
            AV12Audit.gxTpr_Auditdescription = AV15AuditDescription;
            AV12Audit.gxTpr_Auditshortdescription = AV14AuditShortDescription;
            AV12Audit.Save();
            if ( AV12Audit.Success() )
            {
               context.CommitDataStores("wwpbaseobjects.audittransaction",pr_default);
            }
            AV19GXV1 = (int)(AV19GXV1+1);
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
         AV13WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16AuditPrimaryKey = "";
         AV9AuditingObjectRecordItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem(context);
         AV12Audit = new SdtTrn_Audit(context);
         GXt_char1 = "";
         GXt_guid2 = Guid.Empty;
         AV14AuditShortDescription = "";
         AV15AuditDescription = "";
         AV17ActualMode = "";
         AV10AuditingObjectRecordItemAttributeItem = new WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.audittransaction__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.audittransaction__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.audittransaction__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV19GXV1 ;
      private int AV20GXV2 ;
      private int AV21GXV3 ;
      private string GXt_char1 ;
      private string AV17ActualMode ;
      private bool AV18FirstRecord ;
      private string AV15AuditDescription ;
      private string AV11CallerName ;
      private string AV16AuditPrimaryKey ;
      private string AV14AuditShortDescription ;
      private Guid GXt_guid2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject AV8AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem AV9AuditingObjectRecordItem ;
      private SdtTrn_Audit AV12Audit ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject_RecordItem_AttributeItem AV10AuditingObjectRecordItemAttributeItem ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class audittransaction__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class audittransaction__gam : DataStoreHelperBase, IDataStoreHelper
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

public class audittransaction__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
