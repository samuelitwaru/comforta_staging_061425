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
   public class prc_removeresidentfromgroup : GXProcedure
   {
      public prc_removeresidentfromgroup( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_removeresidentfromgroup( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ResidentId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId ,
                           Guid aP3_GroupId ,
                           out bool aP4_isDeleted )
      {
         this.AV8ResidentId = aP0_ResidentId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         this.AV15GroupId = aP3_GroupId;
         this.AV17isDeleted = false ;
         initialize();
         ExecuteImpl();
         aP4_isDeleted=this.AV17isDeleted;
      }

      public bool executeUdp( Guid aP0_ResidentId ,
                              Guid aP1_LocationId ,
                              Guid aP2_OrganisationId ,
                              Guid aP3_GroupId )
      {
         execute(aP0_ResidentId, aP1_LocationId, aP2_OrganisationId, aP3_GroupId, out aP4_isDeleted);
         return AV17isDeleted ;
      }

      public void executeSubmit( Guid aP0_ResidentId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 Guid aP3_GroupId ,
                                 out bool aP4_isDeleted )
      {
         this.AV8ResidentId = aP0_ResidentId;
         this.AV9LocationId = aP1_LocationId;
         this.AV10OrganisationId = aP2_OrganisationId;
         this.AV15GroupId = aP3_GroupId;
         this.AV17isDeleted = false ;
         SubmitImpl();
         aP4_isDeleted=this.AV17isDeleted;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17isDeleted = false;
         /* Using cursor P00HA2 */
         pr_default.execute(0, new Object[] {AV8ResidentId, AV9LocationId, AV10OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00HA2_A11OrganisationId[0];
            A29LocationId = P00HA2_A29LocationId[0];
            A62ResidentId = P00HA2_A62ResidentId[0];
            A670ResidentGroups = P00HA2_A670ResidentGroups[0];
            n670ResidentGroups = P00HA2_n670ResidentGroups[0];
            if ( AV13ResidentPackageIdCollection.FromJSonString(A670ResidentGroups, null) )
            {
               AV16GroupIndexToDelete = 0;
               AV19GXV1 = 1;
               while ( AV19GXV1 <= AV13ResidentPackageIdCollection.Count )
               {
                  AV14ResidentPackageId = ((Guid)AV13ResidentPackageIdCollection.Item(AV19GXV1));
                  if ( AV14ResidentPackageId == AV15GroupId )
                  {
                     AV16GroupIndexToDelete = (short)(AV13ResidentPackageIdCollection.IndexOf(AV14ResidentPackageId));
                  }
                  AV19GXV1 = (int)(AV19GXV1+1);
               }
               if ( AV16GroupIndexToDelete > 0 )
               {
                  AV13ResidentPackageIdCollection.RemoveItem(AV16GroupIndexToDelete);
                  A670ResidentGroups = AV13ResidentPackageIdCollection.ToJSonString(false);
                  n670ResidentGroups = false;
                  AV17isDeleted = true;
               }
            }
            /* Using cursor P00HA3 */
            pr_default.execute(1, new Object[] {n670ResidentGroups, A670ResidentGroups, A62ResidentId, A29LocationId, A11OrganisationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_removeresidentfromgroup",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00HA2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00HA2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00HA2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00HA2_A670ResidentGroups = new string[] {""} ;
         P00HA2_n670ResidentGroups = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         A670ResidentGroups = "";
         AV13ResidentPackageIdCollection = new GxSimpleCollection<Guid>();
         AV14ResidentPackageId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_removeresidentfromgroup__default(),
            new Object[][] {
                new Object[] {
               P00HA2_A11OrganisationId, P00HA2_A29LocationId, P00HA2_A62ResidentId, P00HA2_A670ResidentGroups, P00HA2_n670ResidentGroups
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16GroupIndexToDelete ;
      private int AV19GXV1 ;
      private bool AV17isDeleted ;
      private bool n670ResidentGroups ;
      private string A670ResidentGroups ;
      private Guid AV8ResidentId ;
      private Guid AV9LocationId ;
      private Guid AV10OrganisationId ;
      private Guid AV15GroupId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A62ResidentId ;
      private Guid AV14ResidentPackageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00HA2_A11OrganisationId ;
      private Guid[] P00HA2_A29LocationId ;
      private Guid[] P00HA2_A62ResidentId ;
      private string[] P00HA2_A670ResidentGroups ;
      private bool[] P00HA2_n670ResidentGroups ;
      private GxSimpleCollection<Guid> AV13ResidentPackageIdCollection ;
      private bool aP4_isDeleted ;
   }

   public class prc_removeresidentfromgroup__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00HA2;
          prmP00HA2 = new Object[] {
          new ParDef("AV8ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00HA3;
          prmP00HA3 = new Object[] {
          new ParDef("ResidentGroups",GXType.LongVarChar,1048576,0){Nullable=true} ,
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00HA2", "SELECT OrganisationId, LocationId, ResidentId, ResidentGroups FROM Trn_Resident WHERE ResidentId = :AV8ResidentId and LocationId = :AV9LocationId and OrganisationId = :AV10OrganisationId ORDER BY ResidentId, LocationId, OrganisationId  FOR UPDATE OF Trn_Resident",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HA2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00HA3", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentGroups=:ResidentGroups  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00HA3)
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
