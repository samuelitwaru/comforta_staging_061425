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
   public class prc_getmemocategory : GXProcedure
   {
      public prc_getmemocategory( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getmemocategory( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_MemoCategoryId ,
                           out SdtSDT_MemoCategory aP1_SDT_MemoCategory )
      {
         this.AV9MemoCategoryId = aP0_MemoCategoryId;
         this.AV10SDT_MemoCategory = new SdtSDT_MemoCategory(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_MemoCategory=this.AV10SDT_MemoCategory;
      }

      public SdtSDT_MemoCategory executeUdp( Guid aP0_MemoCategoryId )
      {
         execute(aP0_MemoCategoryId, out aP1_SDT_MemoCategory);
         return AV10SDT_MemoCategory ;
      }

      public void executeSubmit( Guid aP0_MemoCategoryId ,
                                 out SdtSDT_MemoCategory aP1_SDT_MemoCategory )
      {
         this.AV9MemoCategoryId = aP0_MemoCategoryId;
         this.AV10SDT_MemoCategory = new SdtSDT_MemoCategory(context) ;
         SubmitImpl();
         aP1_SDT_MemoCategory=this.AV10SDT_MemoCategory;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CR2 */
         pr_default.execute(0, new Object[] {AV9MemoCategoryId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A542MemoCategoryId = P00CR2_A542MemoCategoryId[0];
            A543MemoCategoryName = P00CR2_A543MemoCategoryName[0];
            AV10SDT_MemoCategory = new SdtSDT_MemoCategory(context);
            AV10SDT_MemoCategory.gxTpr_Memocategoryid = A542MemoCategoryId;
            AV10SDT_MemoCategory.gxTpr_Memocategoryname = A543MemoCategoryName;
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV10SDT_MemoCategory = new SdtSDT_MemoCategory(context);
         P00CR2_A542MemoCategoryId = new Guid[] {Guid.Empty} ;
         P00CR2_A543MemoCategoryName = new string[] {""} ;
         A542MemoCategoryId = Guid.Empty;
         A543MemoCategoryName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getmemocategory__default(),
            new Object[][] {
                new Object[] {
               P00CR2_A542MemoCategoryId, P00CR2_A543MemoCategoryName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A543MemoCategoryName ;
      private Guid AV9MemoCategoryId ;
      private Guid A542MemoCategoryId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_MemoCategory AV10SDT_MemoCategory ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CR2_A542MemoCategoryId ;
      private string[] P00CR2_A543MemoCategoryName ;
      private SdtSDT_MemoCategory aP1_SDT_MemoCategory ;
   }

   public class prc_getmemocategory__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CR2;
          prmP00CR2 = new Object[] {
          new ParDef("AV9MemoCategoryId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CR2", "SELECT MemoCategoryId, MemoCategoryName FROM Trn_MemoCategory WHERE MemoCategoryId = :AV9MemoCategoryId ORDER BY MemoCategoryId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CR2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
