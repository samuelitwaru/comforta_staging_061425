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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_deleteform : GXProcedure
   {
      public wwp_df_deleteform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_deleteform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormId ,
                           short aP1_WWPFormVersionNumber ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.A206WWPFormId = aP0_WWPFormId;
         this.A207WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP2_Messages=this.AV9Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( short aP0_WWPFormId ,
                                                                             short aP1_WWPFormVersionNumber )
      {
         execute(aP0_WWPFormId, aP1_WWPFormVersionNumber, out aP2_Messages);
         return AV9Messages ;
      }

      public void executeSubmit( short aP0_WWPFormId ,
                                 short aP1_WWPFormVersionNumber ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.A206WWPFormId = aP0_WWPFormId;
         this.A207WWPFormVersionNumber = aP1_WWPFormVersionNumber;
         this.AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP2_Messages=this.AV9Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized DELETE. */
         /* Using cursor P004L2 */
         pr_default.execute(0, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
         /* End optimized DELETE. */
         AV8WWP_Form.Load(A206WWPFormId, A207WWPFormVersionNumber);
         AV8WWP_Form.Delete();
         if ( AV8WWP_Form.Success() )
         {
            context.CommitDataStores("workwithplus.dynamicforms.wwp_df_deleteform",pr_default);
         }
         else
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "Error on actual form delete", "")) ;
            context.RollbackDataStores("workwithplus.dynamicforms.wwp_df_deleteform",pr_default);
            AV9Messages = AV8WWP_Form.GetMessages();
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
         AV9Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8WWP_Form = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deleteform__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deleteform__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deleteform__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9Messages ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV8WWP_Form ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_df_deleteform__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_df_deleteform__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_df_deleteform__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new UpdateCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP004L2;
       prmP004L2 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("P004L2", "DELETE FROM WWP_FormElement  WHERE WWPFormId = :WWPFormId and WWPFormVersionNumber = :WWPFormVersionNumber", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP004L2)
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
