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
   public class prc_updatetoolboxstatus : GXProcedure
   {
      public prc_updatetoolboxstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatetoolboxstatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( bool aP0_IsActive )
      {
         this.AV9IsActive = aP0_IsActive;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( bool aP0_IsActive )
      {
         this.AV9IsActive = aP0_IsActive;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_char1 = AV8UserId;
         new prc_getloggedinuserid(context ).execute( out  GXt_char1) ;
         AV8UserId = GXt_char1;
         /* Using cursor P00GF2 */
         pr_default.execute(0, new Object[] {AV8UserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00GF2_A11OrganisationId[0];
            A29LocationId = P00GF2_A29LocationId[0];
            A89ReceptionistId = P00GF2_A89ReceptionistId[0];
            A95ReceptionistGAMGUID = P00GF2_A95ReceptionistGAMGUID[0];
            /* Using cursor P00GF3 */
            pr_default.execute(1, new Object[] {A29LocationId, A11OrganisationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A630ToolBoxLastUpdateReceptionistI = P00GF3_A630ToolBoxLastUpdateReceptionistI[0];
               n630ToolBoxLastUpdateReceptionistI = P00GF3_n630ToolBoxLastUpdateReceptionistI[0];
               A631ToolBoxLastUpdateTime = P00GF3_A631ToolBoxLastUpdateTime[0];
               n631ToolBoxLastUpdateTime = P00GF3_n631ToolBoxLastUpdateTime[0];
               if ( AV9IsActive )
               {
                  A630ToolBoxLastUpdateReceptionistI = A89ReceptionistId;
                  n630ToolBoxLastUpdateReceptionistI = false;
                  A631ToolBoxLastUpdateTime = DateTimeUtil.ResetDate(DateTimeUtil.ServerNow( context, pr_default));
                  n631ToolBoxLastUpdateTime = false;
               }
               else
               {
                  A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
                  n630ToolBoxLastUpdateReceptionistI = false;
                  n630ToolBoxLastUpdateReceptionistI = true;
                  A631ToolBoxLastUpdateTime = (DateTime)(DateTime.MinValue);
                  n631ToolBoxLastUpdateTime = false;
                  n631ToolBoxLastUpdateTime = true;
               }
               /* Using cursor P00GF4 */
               pr_default.execute(2, new Object[] {n630ToolBoxLastUpdateReceptionistI, A630ToolBoxLastUpdateReceptionistI, n631ToolBoxLastUpdateTime, A631ToolBoxLastUpdateTime, A29LocationId, A11OrganisationId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_updatetoolboxstatus",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8UserId = "";
         GXt_char1 = "";
         P00GF2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GF2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GF2_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         P00GF2_A95ReceptionistGAMGUID = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A89ReceptionistId = Guid.Empty;
         A95ReceptionistGAMGUID = "";
         P00GF3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00GF3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00GF3_A630ToolBoxLastUpdateReceptionistI = new Guid[] {Guid.Empty} ;
         P00GF3_n630ToolBoxLastUpdateReceptionistI = new bool[] {false} ;
         P00GF3_A631ToolBoxLastUpdateTime = new DateTime[] {DateTime.MinValue} ;
         P00GF3_n631ToolBoxLastUpdateTime = new bool[] {false} ;
         A630ToolBoxLastUpdateReceptionistI = Guid.Empty;
         A631ToolBoxLastUpdateTime = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatetoolboxstatus__default(),
            new Object[][] {
                new Object[] {
               P00GF2_A11OrganisationId, P00GF2_A29LocationId, P00GF2_A89ReceptionistId, P00GF2_A95ReceptionistGAMGUID
               }
               , new Object[] {
               P00GF3_A29LocationId, P00GF3_A11OrganisationId, P00GF3_A630ToolBoxLastUpdateReceptionistI, P00GF3_n630ToolBoxLastUpdateReceptionistI, P00GF3_A631ToolBoxLastUpdateTime, P00GF3_n631ToolBoxLastUpdateTime
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private DateTime A631ToolBoxLastUpdateTime ;
      private bool AV9IsActive ;
      private bool n630ToolBoxLastUpdateReceptionistI ;
      private bool n631ToolBoxLastUpdateTime ;
      private string AV8UserId ;
      private string A95ReceptionistGAMGUID ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A89ReceptionistId ;
      private Guid A630ToolBoxLastUpdateReceptionistI ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00GF2_A11OrganisationId ;
      private Guid[] P00GF2_A29LocationId ;
      private Guid[] P00GF2_A89ReceptionistId ;
      private string[] P00GF2_A95ReceptionistGAMGUID ;
      private Guid[] P00GF3_A29LocationId ;
      private Guid[] P00GF3_A11OrganisationId ;
      private Guid[] P00GF3_A630ToolBoxLastUpdateReceptionistI ;
      private bool[] P00GF3_n630ToolBoxLastUpdateReceptionistI ;
      private DateTime[] P00GF3_A631ToolBoxLastUpdateTime ;
      private bool[] P00GF3_n631ToolBoxLastUpdateTime ;
   }

   public class prc_updatetoolboxstatus__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GF2;
          prmP00GF2 = new Object[] {
          new ParDef("AV8UserId",GXType.VarChar,100,0)
          };
          Object[] prmP00GF3;
          prmP00GF3 = new Object[] {
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00GF4;
          prmP00GF4 = new Object[] {
          new ParDef("ToolBoxLastUpdateReceptionistI",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("ToolBoxLastUpdateTime",GXType.DateTime,0,5){Nullable=true} ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GF2", "SELECT OrganisationId, LocationId, ReceptionistId, ReceptionistGAMGUID FROM Trn_Receptionist WHERE ReceptionistGAMGUID = ( :AV8UserId) ORDER BY ReceptionistId, OrganisationId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GF2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GF3", "SELECT LocationId, OrganisationId, ToolBoxLastUpdateReceptionistI, ToolBoxLastUpdateTime FROM Trn_Location WHERE LocationId = :LocationId and OrganisationId = :OrganisationId ORDER BY LocationId, OrganisationId  FOR UPDATE OF Trn_Location",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GF3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00GF4", "SAVEPOINT gxupdate;UPDATE Trn_Location SET ToolBoxLastUpdateReceptionistI=:ToolBoxLastUpdateReceptionistI, ToolBoxLastUpdateTime=:ToolBoxLastUpdateTime  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00GF4)
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
