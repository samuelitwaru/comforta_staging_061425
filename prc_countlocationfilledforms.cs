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
   public class prc_countlocationfilledforms : GXProcedure
   {
      public prc_countlocationfilledforms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_countlocationfilledforms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_LocationFilledFormsCount )
      {
         this.AV13LocationFilledFormsCount = 0 ;
         initialize();
         ExecuteImpl();
         aP0_LocationFilledFormsCount=this.AV13LocationFilledFormsCount;
      }

      public short executeUdp( )
      {
         execute(out aP0_LocationFilledFormsCount);
         return AV13LocationFilledFormsCount ;
      }

      public void executeSubmit( out short aP0_LocationFilledFormsCount )
      {
         this.AV13LocationFilledFormsCount = 0 ;
         SubmitImpl();
         aP0_LocationFilledFormsCount=this.AV13LocationFilledFormsCount;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13LocationFilledFormsCount = 0;
         /* Using cursor P00EO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112WWPUserExtendedId = P00EO2_A112WWPUserExtendedId[0];
            A214WWPFormInstanceId = P00EO2_A214WWPFormInstanceId[0];
            AV12WWPUserExtendedId = A112WWPUserExtendedId;
            AV16Udparg1 = new prc_getuserlocationid(context).executeUdp( );
            /* Optimized group. */
            /* Using cursor P00EO3 */
            pr_default.execute(1, new Object[] {AV16Udparg1, AV12WWPUserExtendedId});
            cV13LocationFilledFormsCount = P00EO3_AV13LocationFilledFormsCount[0];
            pr_default.close(1);
            AV13LocationFilledFormsCount = (short)(AV13LocationFilledFormsCount+cV13LocationFilledFormsCount*1);
            /* End optimized group. */
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P00EO2_A112WWPUserExtendedId = new string[] {""} ;
         P00EO2_A214WWPFormInstanceId = new int[1] ;
         A112WWPUserExtendedId = "";
         AV12WWPUserExtendedId = "";
         AV16Udparg1 = Guid.Empty;
         P00EO3_AV13LocationFilledFormsCount = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_countlocationfilledforms__default(),
            new Object[][] {
                new Object[] {
               P00EO2_A112WWPUserExtendedId, P00EO2_A214WWPFormInstanceId
               }
               , new Object[] {
               P00EO3_AV13LocationFilledFormsCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13LocationFilledFormsCount ;
      private short cV13LocationFilledFormsCount ;
      private int A214WWPFormInstanceId ;
      private string A112WWPUserExtendedId ;
      private string AV12WWPUserExtendedId ;
      private Guid AV16Udparg1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00EO2_A112WWPUserExtendedId ;
      private int[] P00EO2_A214WWPFormInstanceId ;
      private short[] P00EO3_AV13LocationFilledFormsCount ;
      private short aP0_LocationFilledFormsCount ;
   }

   public class prc_countlocationfilledforms__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EO2;
          prmP00EO2 = new Object[] {
          };
          Object[] prmP00EO3;
          prmP00EO3 = new Object[] {
          new ParDef("AV16Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12WWPUserExtendedId",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EO2", "SELECT WWPUserExtendedId, WWPFormInstanceId FROM WWP_FormInstance ORDER BY WWPFormInstanceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EO3", "SELECT COUNT(*) FROM Trn_Resident WHERE (LocationId = :AV16Udparg1) AND (ResidentGUID = ( :AV12WWPUserExtendedId)) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EO3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
