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
   public class prc_deletelocationform : GXProcedure
   {
      public prc_deletelocationform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletelocationform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationDynamicFormId ,
                           Guid aP1_OrganisationId ,
                           Guid aP2_LocationId ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_OutMessage )
      {
         this.A366LocationDynamicFormId = aP0_LocationDynamicFormId;
         this.A11OrganisationId = aP1_OrganisationId;
         this.A29LocationId = aP2_LocationId;
         this.AV9OutMessage = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP3_OutMessage=this.AV9OutMessage;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( Guid aP0_LocationDynamicFormId ,
                                                                             Guid aP1_OrganisationId ,
                                                                             Guid aP2_LocationId )
      {
         execute(aP0_LocationDynamicFormId, aP1_OrganisationId, aP2_LocationId, out aP3_OutMessage);
         return AV9OutMessage ;
      }

      public void executeSubmit( Guid aP0_LocationDynamicFormId ,
                                 Guid aP1_OrganisationId ,
                                 Guid aP2_LocationId ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_OutMessage )
      {
         this.A366LocationDynamicFormId = aP0_LocationDynamicFormId;
         this.A11OrganisationId = aP1_OrganisationId;
         this.A29LocationId = aP2_LocationId;
         this.AV9OutMessage = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP3_OutMessage=this.AV9OutMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized DELETE. */
         /* Using cursor P007H2 */
         pr_default.execute(0, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
         /* End optimized DELETE. */
         AV8Trn_LocationDynamicForm.Load(A366LocationDynamicFormId, A11OrganisationId, A29LocationId);
         AV8Trn_LocationDynamicForm.Delete();
         if ( AV8Trn_LocationDynamicForm.Success() )
         {
            /* Using cursor P007H3 */
            pr_default.execute(1, new Object[] {AV8Trn_LocationDynamicForm.gxTpr_Wwpformid, AV8Trn_LocationDynamicForm.gxTpr_Wwpformversionnumber});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A214WWPFormInstanceId = P007H3_A214WWPFormInstanceId[0];
               A207WWPFormVersionNumber = P007H3_A207WWPFormVersionNumber[0];
               A206WWPFormId = P007H3_A206WWPFormId[0];
               /* Optimized DELETE. */
               /* Using cursor P007H4 */
               pr_default.execute(2, new Object[] {A214WWPFormInstanceId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
               /* End optimized DELETE. */
               /* Using cursor P007H5 */
               pr_default.execute(3, new Object[] {A214WWPFormInstanceId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deleteform(context ).execute(  AV8Trn_LocationDynamicForm.gxTpr_Wwpformid,  AV8Trn_LocationDynamicForm.gxTpr_Wwpformversionnumber, out  AV9OutMessage) ;
         }
         else
         {
            AV9OutMessage = AV8Trn_LocationDynamicForm.GetMessages();
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_deletelocationform",pr_default);
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
         AV8Trn_LocationDynamicForm = new SdtTrn_LocationDynamicForm(context);
         P007H3_A214WWPFormInstanceId = new int[1] ;
         P007H3_A207WWPFormVersionNumber = new short[1] ;
         P007H3_A206WWPFormId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletelocationform__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               P007H3_A214WWPFormInstanceId, P007H3_A207WWPFormVersionNumber, P007H3_A206WWPFormId
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
      private bool n366LocationDynamicFormId ;
      private Guid A366LocationDynamicFormId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9OutMessage ;
      private IDataStoreProvider pr_default ;
      private SdtTrn_LocationDynamicForm AV8Trn_LocationDynamicForm ;
      private int[] P007H3_A214WWPFormInstanceId ;
      private short[] P007H3_A207WWPFormVersionNumber ;
      private short[] P007H3_A206WWPFormId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_OutMessage ;
   }

   public class prc_deletelocationform__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007H2;
          prmP007H2 = new Object[] {
          new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007H3;
          prmP007H3 = new Object[] {
          new ParDef("AV8Trn_L_2Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV8Trn_L_1Wwpformversionnumbe",GXType.Int16,4,0)
          };
          Object[] prmP007H4;
          prmP007H4 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          Object[] prmP007H5;
          prmP007H5 = new Object[] {
          new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007H2", "DELETE FROM Trn_CallToAction  WHERE LocationDynamicFormId = :LocationDynamicFormId and OrganisationId = :OrganisationId and LocationId = :LocationId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007H2)
             ,new CursorDef("P007H3", "SELECT WWPFormInstanceId, WWPFormVersionNumber, WWPFormId FROM WWP_FormInstance WHERE WWPFormId = :AV8Trn_L_2Wwpformid and WWPFormVersionNumber = :AV8Trn_L_1Wwpformversionnumbe ORDER BY WWPFormId, WWPFormVersionNumber  FOR UPDATE OF WWP_FormInstance",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007H4", "DELETE FROM WWP_FormInstanceElement  WHERE WWPFormInstanceId = :WWPFormInstanceId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007H4)
             ,new CursorDef("P007H5", "SAVEPOINT gxupdate;DELETE FROM WWP_FormInstance  WHERE WWPFormInstanceId = :WWPFormInstanceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007H5)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
