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
   public class prc_deletesupplierform : GXProcedure
   {
      public prc_deletesupplierform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletesupplierform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_SupplierDynamicFormId ,
                           Guid aP1_SupplierGenId ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_OutMessage )
      {
         this.A616SupplierDynamicFormId = aP0_SupplierDynamicFormId;
         this.A42SupplierGenId = aP1_SupplierGenId;
         this.AV9OutMessage = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP2_OutMessage=this.AV9OutMessage;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( Guid aP0_SupplierDynamicFormId ,
                                                                             Guid aP1_SupplierGenId )
      {
         execute(aP0_SupplierDynamicFormId, aP1_SupplierGenId, out aP2_OutMessage);
         return AV9OutMessage ;
      }

      public void executeSubmit( Guid aP0_SupplierDynamicFormId ,
                                 Guid aP1_SupplierGenId ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_OutMessage )
      {
         this.A616SupplierDynamicFormId = aP0_SupplierDynamicFormId;
         this.A42SupplierGenId = aP1_SupplierGenId;
         this.AV9OutMessage = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP2_OutMessage=this.AV9OutMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Trn_SupplierDynamicForm.Load(A616SupplierDynamicFormId, A42SupplierGenId);
         AV8Trn_SupplierDynamicForm.Delete();
         if ( AV8Trn_SupplierDynamicForm.Success() )
         {
            /* Using cursor P00G52 */
            pr_default.execute(0, new Object[] {AV8Trn_SupplierDynamicForm.gxTpr_Wwpformid, AV8Trn_SupplierDynamicForm.gxTpr_Wwpformversionnumber});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A214WWPFormInstanceId = P00G52_A214WWPFormInstanceId[0];
               A207WWPFormVersionNumber = P00G52_A207WWPFormVersionNumber[0];
               A206WWPFormId = P00G52_A206WWPFormId[0];
               /* Optimized DELETE. */
               /* Using cursor P00G53 */
               pr_default.execute(1, new Object[] {A214WWPFormInstanceId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
               /* End optimized DELETE. */
               /* Using cursor P00G54 */
               pr_default.execute(2, new Object[] {A214WWPFormInstanceId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
               pr_default.readNext(0);
            }
            pr_default.close(0);
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deleteform(context ).execute(  AV8Trn_SupplierDynamicForm.gxTpr_Wwpformid,  AV8Trn_SupplierDynamicForm.gxTpr_Wwpformversionnumber, out  AV9OutMessage) ;
         }
         else
         {
            AV9OutMessage = AV8Trn_SupplierDynamicForm.GetMessages();
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletesupplierform",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9OutMessage = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8Trn_SupplierDynamicForm = new SdtTrn_SupplierDynamicForm(context);
         P00G52_A214WWPFormInstanceId = new int[1] ;
         P00G52_A207WWPFormVersionNumber = new short[1] ;
         P00G52_A206WWPFormId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletesupplierform__default(),
            new Object[][] {
                new Object[] {
               P00G52_A214WWPFormInstanceId, P00G52_A207WWPFormVersionNumber, P00G52_A206WWPFormId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private int A214WWPFormInstanceId ;
      private Guid A616SupplierDynamicFormId ;
      private Guid A42SupplierGenId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9OutMessage ;
      private SdtTrn_SupplierDynamicForm AV8Trn_SupplierDynamicForm ;
      private IDataStoreProvider pr_default ;
      private int[] P00G52_A214WWPFormInstanceId ;
      private short[] P00G52_A207WWPFormVersionNumber ;
      private short[] P00G52_A206WWPFormId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_OutMessage ;
   }

   public class prc_deletesupplierform__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00G52;
          prmP00G52 = new Object[] {
          new ParDef("AV8Trn_S_2Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV8Trn_S_1Wwpformversionnumbe",GXType.Int16,4,0)
          };
          Object[] prmP00G53;
          prmP00G53 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmP00G54;
          prmP00G54 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G52", "SELECT WWPFormInstanceId, WWPFormVersionNumber, WWPFormId FROM WWP_FormInstance WHERE WWPFormId = :AV8Trn_S_2Wwpformid and WWPFormVersionNumber = :AV8Trn_S_1Wwpformversionnumbe ORDER BY WWPFormId, WWPFormVersionNumber  FOR UPDATE OF WWP_FormInstance",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G52,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00G53", "DELETE FROM WWP_FormInstanceElement  WHERE WWPFormInstanceId = :WWPFormInstanceId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00G53)
             ,new CursorDef("P00G54", "SAVEPOINT gxupdate;DELETE FROM WWP_FormInstance  WHERE WWPFormInstanceId = :WWPFormInstanceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00G54)
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
