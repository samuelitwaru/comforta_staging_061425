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
   public class aprc_initializeresidentgroups : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprc_initializeresidentgroups().MainImpl(args); ;
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

      public aprc_initializeresidentgroups( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprc_initializeresidentgroups( IGxContext context )
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
         /* Using cursor P00H42 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A527ResidentPackageId = P00H42_A527ResidentPackageId[0];
            n527ResidentPackageId = P00H42_n527ResidentPackageId[0];
            A670ResidentGroups = P00H42_A670ResidentGroups[0];
            n670ResidentGroups = P00H42_n670ResidentGroups[0];
            A62ResidentId = P00H42_A62ResidentId[0];
            A29LocationId = P00H42_A29LocationId[0];
            A11OrganisationId = P00H42_A11OrganisationId[0];
            if ( ! (Guid.Empty==A527ResidentPackageId) )
            {
               A670ResidentGroups = "[\"" + A527ResidentPackageId.ToString() + "\"]";
               n670ResidentGroups = false;
            }
            /* Using cursor P00H43 */
            pr_default.execute(1, new Object[] {n670ResidentGroups, A670ResidentGroups, A62ResidentId, A29LocationId, A11OrganisationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_initializeresidentgroups",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00H42_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         P00H42_n527ResidentPackageId = new bool[] {false} ;
         P00H42_A670ResidentGroups = new string[] {""} ;
         P00H42_n670ResidentGroups = new bool[] {false} ;
         P00H42_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00H42_A29LocationId = new Guid[] {Guid.Empty} ;
         P00H42_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A527ResidentPackageId = Guid.Empty;
         A670ResidentGroups = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprc_initializeresidentgroups__default(),
            new Object[][] {
                new Object[] {
               P00H42_A527ResidentPackageId, P00H42_n527ResidentPackageId, P00H42_A670ResidentGroups, P00H42_n670ResidentGroups, P00H42_A62ResidentId, P00H42_A29LocationId, P00H42_A11OrganisationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n527ResidentPackageId ;
      private bool n670ResidentGroups ;
      private string A670ResidentGroups ;
      private Guid A527ResidentPackageId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00H42_A527ResidentPackageId ;
      private bool[] P00H42_n527ResidentPackageId ;
      private string[] P00H42_A670ResidentGroups ;
      private bool[] P00H42_n670ResidentGroups ;
      private Guid[] P00H42_A62ResidentId ;
      private Guid[] P00H42_A29LocationId ;
      private Guid[] P00H42_A11OrganisationId ;
   }

   public class aprc_initializeresidentgroups__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00H42;
          prmP00H42 = new Object[] {
          };
          Object[] prmP00H43;
          prmP00H43 = new Object[] {
          new ParDef("ResidentGroups",GXType.LongVarChar,1048576,0){Nullable=true} ,
          new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00H42", "SELECT ResidentPackageId, ResidentGroups, ResidentId, LocationId, OrganisationId FROM Trn_Resident ORDER BY ResidentId, LocationId, OrganisationId  FOR UPDATE OF Trn_Resident",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H42,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00H43", "SAVEPOINT gxupdate;UPDATE Trn_Resident SET ResidentGroups=:ResidentGroups  WHERE ResidentId = :ResidentId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00H43)
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((Guid[]) buf[6])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
