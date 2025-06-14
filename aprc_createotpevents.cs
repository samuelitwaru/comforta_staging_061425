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
   public class aprc_createotpevents : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_createotpevents().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

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

      public aprc_createotpevents( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_createotpevents( IGxContext context )
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
         AV12GAMEvents = "user-otp-validateuser";
         AV15EventDescription = context.GetMessage( "Validate User", "");
         /* Execute user subroutine: 'CREATEOTPEVENT' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV12GAMEvents = "user-otp-generatecode";
         AV15EventDescription = context.GetMessage( "Generate OTP", "");
         /* Execute user subroutine: 'CREATEOTPEVENT' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV12GAMEvents = "user-otp-sendcode";
         AV15EventDescription = context.GetMessage( "Send OTP", "");
         /* Execute user subroutine: 'CREATEOTPEVENT' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV12GAMEvents = "user-otp-validatecode";
         AV15EventDescription = context.GetMessage( "Validate OTP", "");
         /* Execute user subroutine: 'CREATEOTPEVENT' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKIFEVENTEXISTS' Routine */
         returnInSub = false;
         AV13isExisting = false;
         AV14GAMEventSubscriptionFilter.gxTpr_Event = AV12GAMEvents;
         AV14GAMEventSubscriptionFilter.gxTpr_Descripction = AV15EventDescription;
         AV11GAMEventSubscriptionCollection = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).geteventsubscriptions(AV14GAMEventSubscriptionFilter, out  AV16GAMErrorCollection);
         if ( AV11GAMEventSubscriptionCollection.Count > 0 )
         {
            AV13isExisting = true;
         }
      }

      protected void S121( )
      {
         /* 'CREATEOTPEVENT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKIFEVENTEXISTS' */
         S111 ();
         if (returnInSub) return;
         if ( ! AV13isExisting )
         {
            AV8GAMEventSubscription = new GeneXus.Programs.genexussecurity.SdtGAMEventSubscription(context);
            AV8GAMEventSubscription.gxTpr_Description = AV15EventDescription;
            AV8GAMEventSubscription.gxTpr_Event = AV12GAMEvents;
            AV17FileName = context.GetMessage( "aprc_handleotpevents.dll", "");
            AV18ClassName = context.GetMessage( "GeneXus.Programs.aprc_handleotpevents", "");
            AV8GAMEventSubscription.gxTpr_Filename = AV17FileName;
            AV8GAMEventSubscription.gxTpr_Classname = AV18ClassName;
            AV8GAMEventSubscription.gxTpr_Methodname = "execute";
            AV8GAMEventSubscription.save();
            if ( AV8GAMEventSubscription.success() )
            {
               context.CommitDataStores("prc_createotpevents",pr_default);
               AV22Ok = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).subscribeevent(AV8GAMEventSubscription.gxTpr_Id, out  AV16GAMErrorCollection);
               if ( AV22Ok )
               {
                  /* Execute user subroutine: 'CONVERTGAMERRORTOMESSAGES' */
                  S131 ();
                  if (returnInSub) return;
                  context.CommitDataStores("prc_createotpevents",pr_default);
               }
               else
               {
                  new prc_logtofile(context ).execute(  StringUtil.Format( "GAMEvents: %1 - %2, Fail to activate event: %3", AV12GAMEvents, GeneXus.Programs.genexussecuritycommon.gxdomaingamevents.getDescription(context,AV12GAMEvents), AV19Messages.ToJSonString(false), "", "", "", "", "", "")) ;
               }
            }
            else
            {
               AV16GAMErrorCollection = AV8GAMEventSubscription.geterrors();
               /* Execute user subroutine: 'CONVERTGAMERRORTOMESSAGES' */
               S131 ();
               if (returnInSub) return;
               new prc_logtofile(context ).execute(  StringUtil.Format( "GAMEvents: %1 - %2, Fail to subscribe: %3", AV12GAMEvents, GeneXus.Programs.genexussecuritycommon.gxdomaingamevents.getDescription(context,AV12GAMEvents), AV19Messages.ToJSonString(false), "", "", "", "", "", "")) ;
            }
         }
      }

      protected void S131( )
      {
         /* 'CONVERTGAMERRORTOMESSAGES' Routine */
         returnInSub = false;
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV16GAMErrorCollection.Count )
         {
            AV20GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV16GAMErrorCollection.Item(AV23GXV1));
            AV21Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV21Message.gxTpr_Type = 1;
            AV21Message.gxTpr_Description = AV20GAMError.gxTpr_Message;
            AV21Message.gxTpr_Id = StringUtil.Format( "GAM%2", StringUtil.LTrimStr( (decimal)(AV20GAMError.gxTpr_Code), 12, 0), "", "", "", "", "", "", "", "");
            AV19Messages.Add(AV21Message, 0);
            AV23GXV1 = (int)(AV23GXV1+1);
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
         AV12GAMEvents = "";
         AV15EventDescription = "";
         AV14GAMEventSubscriptionFilter = new GeneXus.Programs.genexussecurity.SdtGAMEventSubscriptionFilter(context);
         AV11GAMEventSubscriptionCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription>( context, "GeneXus.Programs.genexussecurity.SdtGAMEventSubscription", "GeneXus.Programs");
         AV16GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV8GAMEventSubscription = new GeneXus.Programs.genexussecurity.SdtGAMEventSubscription(context);
         AV17FileName = "";
         AV18ClassName = "";
         AV19Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV20GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV21Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aprc_createotpevents__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.aprc_createotpevents__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_createotpevents__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV23GXV1 ;
      private string AV12GAMEvents ;
      private bool returnInSub ;
      private bool AV13isExisting ;
      private bool AV22Ok ;
      private string AV15EventDescription ;
      private string AV17FileName ;
      private string AV18ClassName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMEventSubscriptionFilter AV14GAMEventSubscriptionFilter ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMEventSubscription> AV11GAMEventSubscriptionCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV16GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMEventSubscription AV8GAMEventSubscription ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV19Messages ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV20GAMError ;
      private GeneXus.Utils.SdtMessages_Message AV21Message ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class aprc_createotpevents__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprc_createotpevents__gam : DataStoreHelperBase, IDataStoreHelper
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

public class aprc_createotpevents__default : DataStoreHelperBase, IDataStoreHelper
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
