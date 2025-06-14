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
   public class wwp_updatenotificationdefinitions : GXProcedure
   {
      public wwp_updatenotificationdefinitions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_updatenotificationdefinitions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16MailTemplatePath = "C:\\Program Files (x86)\\GeneXus\\GeneXus18\\Packages\\Patterns\\WorkWithPlus\\Resources\\MailNotificationTemplate.html";
         /* Execute user subroutine: 'UPDATE NOTIFICATION DEFINITIONS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'IMPORT MAIL TEMPLATE' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_updatenotificationdefinitions",pr_default);
         cleanup();
      }

      protected void S111( )
      {
         /* 'UPDATE NOTIFICATION DEFINITIONS' Routine */
         returnInSub = false;
         GXt_objcol_SdtWWP_NotificationDefinition1 = AV10WWP_NotificationDefinitionCollection;
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_automaticnotificationdefinitionstoload(context ).execute( out  GXt_objcol_SdtWWP_NotificationDefinition1) ;
         AV10WWP_NotificationDefinitionCollection = GXt_objcol_SdtWWP_NotificationDefinition1;
         AV17GXV1 = 1;
         while ( AV17GXV1 <= AV10WWP_NotificationDefinitionCollection.Count )
         {
            AV11WWP_NotificationDefinition = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition)AV10WWP_NotificationDefinitionCollection.Item(AV17GXV1));
            GXt_int2 = AV13WWPNotificationDefinitionId;
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_getnotificationdefinitionbyname(context ).execute(  AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitionname,  AV11WWP_NotificationDefinition.gxTpr_Wwpentityid, out  GXt_int2) ;
            AV13WWPNotificationDefinitionId = GXt_int2;
            if ( AV13WWPNotificationDefinitionId > 0 )
            {
               context.StatusMessage( StringUtil.Format( "Updating Notification %1...", AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitionname, "", "", "", "", "", "", "", "") );
               AV12WWP_NotificationDefinitionToUpdate.Load(AV13WWPNotificationDefinitionId);
               AV12WWP_NotificationDefinitionToUpdate.gxTpr_Wwpnotificationdefinitionallowusersubscription = AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitionallowusersubscription;
               AV12WWP_NotificationDefinitionToUpdate.gxTpr_Wwpnotificationdefinitionappliesto = AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitionappliesto;
               AV12WWP_NotificationDefinitionToUpdate.gxTpr_Wwpnotificationdefinitiondescription = AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitiondescription;
               AV12WWP_NotificationDefinitionToUpdate.gxTpr_Wwpnotificationdefinitionicon = AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitionicon;
               AV12WWP_NotificationDefinitionToUpdate.gxTpr_Wwpnotificationdefinitionlink = AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitionlink;
               AV12WWP_NotificationDefinitionToUpdate.gxTpr_Wwpnotificationdefinitionlongdescription = AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitionlongdescription;
               AV12WWP_NotificationDefinitionToUpdate.gxTpr_Wwpnotificationdefinitionshortdescription = AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitionshortdescription;
               AV12WWP_NotificationDefinitionToUpdate.gxTpr_Wwpnotificationdefinitiontitle = AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitiontitle;
               AV12WWP_NotificationDefinitionToUpdate.gxTpr_Wwpnotificationdefinitionsecfuncionality = AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitionsecfuncionality;
               AV12WWP_NotificationDefinitionToUpdate.Save();
               if ( AV12WWP_NotificationDefinitionToUpdate.Fail() )
               {
                  context.StatusMessage( "Error: "+AV12WWP_NotificationDefinitionToUpdate.GetMessages().ToJSonString(false) );
               }
            }
            else
            {
               context.StatusMessage( StringUtil.Format( "Creating Notification %1...", AV11WWP_NotificationDefinition.gxTpr_Wwpnotificationdefinitionname, "", "", "", "", "", "", "", "") );
               AV11WWP_NotificationDefinition.Save();
               if ( AV11WWP_NotificationDefinition.Fail() )
               {
                  context.StatusMessage( "Error: "+AV11WWP_NotificationDefinition.GetMessages().ToJSonString(false) );
               }
            }
            AV17GXV1 = (int)(AV17GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'IMPORT MAIL TEMPLATE' Routine */
         returnInSub = false;
         AV15MailTemplate.Load("MailNotification");
         if ( AV15MailTemplate.Fail() )
         {
            context.StatusMessage( "Importing Mail template..." );
            AV14TemplateFile.Source = AV16MailTemplatePath;
            AV15MailTemplate = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
            AV15MailTemplate.gxTpr_Wwpmailtemplatename = "MailNotification";
            AV15MailTemplate.gxTpr_Wwpmailtemplatedescription = "Template for sending notifications";
            new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "Sender_Name", ref  AV8SenderName) ;
            AV15MailTemplate.gxTpr_Wwpmailtemplatesendername = AV8SenderName;
            new GeneXus.Programs.wwpbaseobjects.wwp_getparameter(context ).gxep_text(  "Sender_Address", ref  AV9SenderAddress) ;
            AV15MailTemplate.gxTpr_Wwpmailtemplatesenderaddress = AV9SenderAddress;
            AV15MailTemplate.gxTpr_Wwpmailtemplatesubject = "New notification";
            AV15MailTemplate.gxTpr_Wwpmailtemplatebody = AV14TemplateFile.ReadAllText("");
            AV15MailTemplate.Save();
         }
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
         AV16MailTemplatePath = "";
         AV10WWP_NotificationDefinitionCollection = new GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition>( context, "WWP_NotificationDefinition", "Comforta_version21");
         GXt_objcol_SdtWWP_NotificationDefinition1 = new GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition>( context, "WWP_NotificationDefinition", "Comforta_version21");
         AV11WWP_NotificationDefinition = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         AV12WWP_NotificationDefinitionToUpdate = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
         AV15MailTemplate = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
         AV14TemplateFile = new GxFile(context.GetPhysicalPath());
         AV8SenderName = "";
         AV9SenderAddress = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_updatenotificationdefinitions__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_updatenotificationdefinitions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_updatenotificationdefinitions__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV17GXV1 ;
      private long AV13WWPNotificationDefinitionId ;
      private long GXt_int2 ;
      private bool returnInSub ;
      private string AV16MailTemplatePath ;
      private string AV8SenderName ;
      private string AV9SenderAddress ;
      private GxFile AV14TemplateFile ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> AV10WWP_NotificationDefinitionCollection ;
      private GXBCCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition> GXt_objcol_SdtWWP_NotificationDefinition1 ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition AV11WWP_NotificationDefinition ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition AV12WWP_NotificationDefinitionToUpdate ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate AV15MailTemplate ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_updatenotificationdefinitions__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_updatenotificationdefinitions__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_updatenotificationdefinitions__default : DataStoreHelperBase, IDataStoreHelper
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
