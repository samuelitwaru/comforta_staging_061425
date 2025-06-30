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
   public class prc_getmemo : GXProcedure
   {
      public prc_getmemo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getmemo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_MemoId ,
                           out SdtSDT_Memo aP1_SDT_Memo )
      {
         this.AV8MemoId = aP0_MemoId;
         this.AV9SDT_Memo = new SdtSDT_Memo(context) ;
         initialize();
         ExecuteImpl();
         aP1_SDT_Memo=this.AV9SDT_Memo;
      }

      public SdtSDT_Memo executeUdp( Guid aP0_MemoId )
      {
         execute(aP0_MemoId, out aP1_SDT_Memo);
         return AV9SDT_Memo ;
      }

      public void executeSubmit( Guid aP0_MemoId ,
                                 out SdtSDT_Memo aP1_SDT_Memo )
      {
         this.AV8MemoId = aP0_MemoId;
         this.AV9SDT_Memo = new SdtSDT_Memo(context) ;
         SubmitImpl();
         aP1_SDT_Memo=this.AV9SDT_Memo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CV2 */
         pr_default.execute(0, new Object[] {AV8MemoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A528SG_LocationId = P00CV2_A528SG_LocationId[0];
            A29LocationId = P00CV2_A29LocationId[0];
            A529SG_OrganisationId = P00CV2_A529SG_OrganisationId[0];
            A11OrganisationId = P00CV2_A11OrganisationId[0];
            A549MemoId = P00CV2_A549MemoId[0];
            A550MemoTitle = P00CV2_A550MemoTitle[0];
            A551MemoDescription = P00CV2_A551MemoDescription[0];
            A552MemoImage = P00CV2_A552MemoImage[0];
            n552MemoImage = P00CV2_n552MemoImage[0];
            A553MemoDocument = P00CV2_A553MemoDocument[0];
            n553MemoDocument = P00CV2_n553MemoDocument[0];
            A561MemoStartDateTime = P00CV2_A561MemoStartDateTime[0];
            n561MemoStartDateTime = P00CV2_n561MemoStartDateTime[0];
            A562MemoEndDateTime = P00CV2_A562MemoEndDateTime[0];
            n562MemoEndDateTime = P00CV2_n562MemoEndDateTime[0];
            A563MemoDuration = P00CV2_A563MemoDuration[0];
            n563MemoDuration = P00CV2_n563MemoDuration[0];
            A564MemoRemoveDate = P00CV2_A564MemoRemoveDate[0];
            n564MemoRemoveDate = P00CV2_n564MemoRemoveDate[0];
            A62ResidentId = P00CV2_A62ResidentId[0];
            A72ResidentSalutation = P00CV2_A72ResidentSalutation[0];
            A64ResidentGivenName = P00CV2_A64ResidentGivenName[0];
            A65ResidentLastName = P00CV2_A65ResidentLastName[0];
            A71ResidentGUID = P00CV2_A71ResidentGUID[0];
            A566MemoBgColorCode = P00CV2_A566MemoBgColorCode[0];
            n566MemoBgColorCode = P00CV2_n566MemoBgColorCode[0];
            A567MemoForm = P00CV2_A567MemoForm[0];
            A624MemoType = P00CV2_A624MemoType[0];
            A625MemoName = P00CV2_A625MemoName[0];
            A626MemoLeftOffset = P00CV2_A626MemoLeftOffset[0];
            A627MemoTopOffset = P00CV2_A627MemoTopOffset[0];
            A628MemoTitleAngle = P00CV2_A628MemoTitleAngle[0];
            A629MemoTitleScale = P00CV2_A629MemoTitleScale[0];
            A637MemoTextFontName = P00CV2_A637MemoTextFontName[0];
            A638MemoTextAlignment = P00CV2_A638MemoTextAlignment[0];
            A639MemoIsBold = P00CV2_A639MemoIsBold[0];
            A640MemoIsItalic = P00CV2_A640MemoIsItalic[0];
            A641MemoIsCapitalized = P00CV2_A641MemoIsCapitalized[0];
            A642MemoTextColor = P00CV2_A642MemoTextColor[0];
            A647MemoCreatedAt = P00CV2_A647MemoCreatedAt[0];
            n647MemoCreatedAt = P00CV2_n647MemoCreatedAt[0];
            A72ResidentSalutation = P00CV2_A72ResidentSalutation[0];
            A64ResidentGivenName = P00CV2_A64ResidentGivenName[0];
            A65ResidentLastName = P00CV2_A65ResidentLastName[0];
            A71ResidentGUID = P00CV2_A71ResidentGUID[0];
            AV9SDT_Memo = new SdtSDT_Memo(context);
            AV9SDT_Memo.gxTpr_Memoid = A549MemoId;
            AV9SDT_Memo.gxTpr_Memotitle = A550MemoTitle;
            AV9SDT_Memo.gxTpr_Memodescription = A551MemoDescription;
            AV9SDT_Memo.gxTpr_Memoimage = A552MemoImage;
            AV9SDT_Memo.gxTpr_Memodocument = A553MemoDocument;
            AV9SDT_Memo.gxTpr_Memostartdatetime = A561MemoStartDateTime;
            AV9SDT_Memo.gxTpr_Memoenddatetime = A562MemoEndDateTime;
            AV9SDT_Memo.gxTpr_Memoduration = (decimal)(NumberUtil.Int( (long)(Math.Round(A563MemoDuration, 18, MidpointRounding.ToEven))));
            AV9SDT_Memo.gxTpr_Memoremovedate = A564MemoRemoveDate;
            AV9SDT_Memo.gxTpr_Residentid = A62ResidentId;
            AV9SDT_Memo.gxTpr_Residentsalutation = A72ResidentSalutation;
            AV9SDT_Memo.gxTpr_Residentgivenname = A64ResidentGivenName;
            AV9SDT_Memo.gxTpr_Residentlastname = A65ResidentLastName;
            AV9SDT_Memo.gxTpr_Residentguid = A71ResidentGUID;
            AV9SDT_Memo.gxTpr_Memobgcolorcode = A566MemoBgColorCode;
            AV9SDT_Memo.gxTpr_Memoform = A567MemoForm;
            AV9SDT_Memo.gxTpr_Createdby = A64ResidentGivenName+" "+A65ResidentLastName;
            AV9SDT_Memo.gxTpr_Memotype = A624MemoType;
            AV9SDT_Memo.gxTpr_Memoname = A625MemoName;
            AV9SDT_Memo.gxTpr_Memoleftoffset = A626MemoLeftOffset;
            AV9SDT_Memo.gxTpr_Memotopoffset = A627MemoTopOffset;
            AV9SDT_Memo.gxTpr_Memotitleangle = A628MemoTitleAngle;
            AV9SDT_Memo.gxTpr_Memotitlescale = A629MemoTitleScale;
            AV9SDT_Memo.gxTpr_Memotextfontname = A637MemoTextFontName;
            AV9SDT_Memo.gxTpr_Memotextalignment = A638MemoTextAlignment;
            AV9SDT_Memo.gxTpr_Memoisbold = A639MemoIsBold;
            AV9SDT_Memo.gxTpr_Memoisitalic = A640MemoIsItalic;
            AV9SDT_Memo.gxTpr_Memoiscapitalized = A641MemoIsCapitalized;
            AV9SDT_Memo.gxTpr_Memotextcolor = A642MemoTextColor;
            AV9SDT_Memo.gxTpr_Memocreatedat = A647MemoCreatedAt;
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
         AV9SDT_Memo = new SdtSDT_Memo(context);
         P00CV2_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         P00CV2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00CV2_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         P00CV2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00CV2_A549MemoId = new Guid[] {Guid.Empty} ;
         P00CV2_A550MemoTitle = new string[] {""} ;
         P00CV2_A551MemoDescription = new string[] {""} ;
         P00CV2_A552MemoImage = new string[] {""} ;
         P00CV2_n552MemoImage = new bool[] {false} ;
         P00CV2_A553MemoDocument = new string[] {""} ;
         P00CV2_n553MemoDocument = new bool[] {false} ;
         P00CV2_A561MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         P00CV2_n561MemoStartDateTime = new bool[] {false} ;
         P00CV2_A562MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         P00CV2_n562MemoEndDateTime = new bool[] {false} ;
         P00CV2_A563MemoDuration = new decimal[1] ;
         P00CV2_n563MemoDuration = new bool[] {false} ;
         P00CV2_A564MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         P00CV2_n564MemoRemoveDate = new bool[] {false} ;
         P00CV2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00CV2_A72ResidentSalutation = new string[] {""} ;
         P00CV2_A64ResidentGivenName = new string[] {""} ;
         P00CV2_A65ResidentLastName = new string[] {""} ;
         P00CV2_A71ResidentGUID = new string[] {""} ;
         P00CV2_A566MemoBgColorCode = new string[] {""} ;
         P00CV2_n566MemoBgColorCode = new bool[] {false} ;
         P00CV2_A567MemoForm = new string[] {""} ;
         P00CV2_A624MemoType = new string[] {""} ;
         P00CV2_A625MemoName = new string[] {""} ;
         P00CV2_A626MemoLeftOffset = new decimal[1] ;
         P00CV2_A627MemoTopOffset = new decimal[1] ;
         P00CV2_A628MemoTitleAngle = new decimal[1] ;
         P00CV2_A629MemoTitleScale = new decimal[1] ;
         P00CV2_A637MemoTextFontName = new string[] {""} ;
         P00CV2_A638MemoTextAlignment = new string[] {""} ;
         P00CV2_A639MemoIsBold = new bool[] {false} ;
         P00CV2_A640MemoIsItalic = new bool[] {false} ;
         P00CV2_A641MemoIsCapitalized = new bool[] {false} ;
         P00CV2_A642MemoTextColor = new string[] {""} ;
         P00CV2_A647MemoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00CV2_n647MemoCreatedAt = new bool[] {false} ;
         A528SG_LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A529SG_OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A549MemoId = Guid.Empty;
         A550MemoTitle = "";
         A551MemoDescription = "";
         A552MemoImage = "";
         A553MemoDocument = "";
         A561MemoStartDateTime = (DateTime)(DateTime.MinValue);
         A562MemoEndDateTime = (DateTime)(DateTime.MinValue);
         A564MemoRemoveDate = DateTime.MinValue;
         A62ResidentId = Guid.Empty;
         A72ResidentSalutation = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A71ResidentGUID = "";
         A566MemoBgColorCode = "";
         A567MemoForm = "";
         A624MemoType = "";
         A625MemoName = "";
         A637MemoTextFontName = "";
         A638MemoTextAlignment = "";
         A642MemoTextColor = "";
         A647MemoCreatedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getmemo__default(),
            new Object[][] {
                new Object[] {
               P00CV2_A528SG_LocationId, P00CV2_A29LocationId, P00CV2_A529SG_OrganisationId, P00CV2_A11OrganisationId, P00CV2_A549MemoId, P00CV2_A550MemoTitle, P00CV2_A551MemoDescription, P00CV2_A552MemoImage, P00CV2_n552MemoImage, P00CV2_A553MemoDocument,
               P00CV2_n553MemoDocument, P00CV2_A561MemoStartDateTime, P00CV2_n561MemoStartDateTime, P00CV2_A562MemoEndDateTime, P00CV2_n562MemoEndDateTime, P00CV2_A563MemoDuration, P00CV2_n563MemoDuration, P00CV2_A564MemoRemoveDate, P00CV2_n564MemoRemoveDate, P00CV2_A62ResidentId,
               P00CV2_A72ResidentSalutation, P00CV2_A64ResidentGivenName, P00CV2_A65ResidentLastName, P00CV2_A71ResidentGUID, P00CV2_A566MemoBgColorCode, P00CV2_n566MemoBgColorCode, P00CV2_A567MemoForm, P00CV2_A624MemoType, P00CV2_A625MemoName, P00CV2_A626MemoLeftOffset,
               P00CV2_A627MemoTopOffset, P00CV2_A628MemoTitleAngle, P00CV2_A629MemoTitleScale, P00CV2_A637MemoTextFontName, P00CV2_A638MemoTextAlignment, P00CV2_A639MemoIsBold, P00CV2_A640MemoIsItalic, P00CV2_A641MemoIsCapitalized, P00CV2_A642MemoTextColor, P00CV2_A647MemoCreatedAt,
               P00CV2_n647MemoCreatedAt
               }
            }
         );
         /* GeneXus formulas. */
      }

      private decimal A563MemoDuration ;
      private decimal A626MemoLeftOffset ;
      private decimal A627MemoTopOffset ;
      private decimal A628MemoTitleAngle ;
      private decimal A629MemoTitleScale ;
      private string A72ResidentSalutation ;
      private string A567MemoForm ;
      private string A638MemoTextAlignment ;
      private DateTime A561MemoStartDateTime ;
      private DateTime A562MemoEndDateTime ;
      private DateTime A647MemoCreatedAt ;
      private DateTime A564MemoRemoveDate ;
      private bool n552MemoImage ;
      private bool n553MemoDocument ;
      private bool n561MemoStartDateTime ;
      private bool n562MemoEndDateTime ;
      private bool n563MemoDuration ;
      private bool n564MemoRemoveDate ;
      private bool n566MemoBgColorCode ;
      private bool A639MemoIsBold ;
      private bool A640MemoIsItalic ;
      private bool A641MemoIsCapitalized ;
      private bool n647MemoCreatedAt ;
      private string A552MemoImage ;
      private string A550MemoTitle ;
      private string A551MemoDescription ;
      private string A553MemoDocument ;
      private string A64ResidentGivenName ;
      private string A65ResidentLastName ;
      private string A71ResidentGUID ;
      private string A566MemoBgColorCode ;
      private string A624MemoType ;
      private string A625MemoName ;
      private string A637MemoTextFontName ;
      private string A642MemoTextColor ;
      private Guid AV8MemoId ;
      private Guid A528SG_LocationId ;
      private Guid A29LocationId ;
      private Guid A529SG_OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A549MemoId ;
      private Guid A62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Memo AV9SDT_Memo ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CV2_A528SG_LocationId ;
      private Guid[] P00CV2_A29LocationId ;
      private Guid[] P00CV2_A529SG_OrganisationId ;
      private Guid[] P00CV2_A11OrganisationId ;
      private Guid[] P00CV2_A549MemoId ;
      private string[] P00CV2_A550MemoTitle ;
      private string[] P00CV2_A551MemoDescription ;
      private string[] P00CV2_A552MemoImage ;
      private bool[] P00CV2_n552MemoImage ;
      private string[] P00CV2_A553MemoDocument ;
      private bool[] P00CV2_n553MemoDocument ;
      private DateTime[] P00CV2_A561MemoStartDateTime ;
      private bool[] P00CV2_n561MemoStartDateTime ;
      private DateTime[] P00CV2_A562MemoEndDateTime ;
      private bool[] P00CV2_n562MemoEndDateTime ;
      private decimal[] P00CV2_A563MemoDuration ;
      private bool[] P00CV2_n563MemoDuration ;
      private DateTime[] P00CV2_A564MemoRemoveDate ;
      private bool[] P00CV2_n564MemoRemoveDate ;
      private Guid[] P00CV2_A62ResidentId ;
      private string[] P00CV2_A72ResidentSalutation ;
      private string[] P00CV2_A64ResidentGivenName ;
      private string[] P00CV2_A65ResidentLastName ;
      private string[] P00CV2_A71ResidentGUID ;
      private string[] P00CV2_A566MemoBgColorCode ;
      private bool[] P00CV2_n566MemoBgColorCode ;
      private string[] P00CV2_A567MemoForm ;
      private string[] P00CV2_A624MemoType ;
      private string[] P00CV2_A625MemoName ;
      private decimal[] P00CV2_A626MemoLeftOffset ;
      private decimal[] P00CV2_A627MemoTopOffset ;
      private decimal[] P00CV2_A628MemoTitleAngle ;
      private decimal[] P00CV2_A629MemoTitleScale ;
      private string[] P00CV2_A637MemoTextFontName ;
      private string[] P00CV2_A638MemoTextAlignment ;
      private bool[] P00CV2_A639MemoIsBold ;
      private bool[] P00CV2_A640MemoIsItalic ;
      private bool[] P00CV2_A641MemoIsCapitalized ;
      private string[] P00CV2_A642MemoTextColor ;
      private DateTime[] P00CV2_A647MemoCreatedAt ;
      private bool[] P00CV2_n647MemoCreatedAt ;
      private SdtSDT_Memo aP1_SDT_Memo ;
   }

   public class prc_getmemo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CV2;
          prmP00CV2 = new Object[] {
          new ParDef("AV8MemoId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CV2", "SELECT T1.SG_LocationId, T2.LocationId, T1.SG_OrganisationId, T2.OrganisationId, T1.MemoId, T1.MemoTitle, T1.MemoDescription, T1.MemoImage, T1.MemoDocument, T1.MemoStartDateTime, T1.MemoEndDateTime, T1.MemoDuration, T1.MemoRemoveDate, T1.ResidentId, T2.ResidentSalutation, T2.ResidentGivenName, T2.ResidentLastName, T2.ResidentGUID, T1.MemoBgColorCode, T1.MemoForm, T1.MemoType, T1.MemoName, T1.MemoLeftOffset, T1.MemoTopOffset, T1.MemoTitleAngle, T1.MemoTitleScale, T1.MemoTextFontName, T1.MemoTextAlignment, T1.MemoIsBold, T1.MemoIsItalic, T1.MemoIsCapitalized, T1.MemoTextColor, T1.MemoCreatedAt FROM (Trn_Memo T1 INNER JOIN Trn_Resident T2 ON T2.ResidentId = T1.ResidentId AND T2.LocationId = T1.SG_LocationId AND T2.OrganisationId = T1.SG_OrganisationId) WHERE T1.MemoId = :AV8MemoId ORDER BY T1.MemoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CV2,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(12);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(13);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((Guid[]) buf[19])[0] = rslt.getGuid(14);
                ((string[]) buf[20])[0] = rslt.getString(15, 20);
                ((string[]) buf[21])[0] = rslt.getVarchar(16);
                ((string[]) buf[22])[0] = rslt.getVarchar(17);
                ((string[]) buf[23])[0] = rslt.getVarchar(18);
                ((string[]) buf[24])[0] = rslt.getVarchar(19);
                ((bool[]) buf[25])[0] = rslt.wasNull(19);
                ((string[]) buf[26])[0] = rslt.getString(20, 20);
                ((string[]) buf[27])[0] = rslt.getVarchar(21);
                ((string[]) buf[28])[0] = rslt.getVarchar(22);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(26);
                ((string[]) buf[33])[0] = rslt.getVarchar(27);
                ((string[]) buf[34])[0] = rslt.getString(28, 20);
                ((bool[]) buf[35])[0] = rslt.getBool(29);
                ((bool[]) buf[36])[0] = rslt.getBool(30);
                ((bool[]) buf[37])[0] = rslt.getBool(31);
                ((string[]) buf[38])[0] = rslt.getVarchar(32);
                ((DateTime[]) buf[39])[0] = rslt.getGXDateTime(33);
                ((bool[]) buf[40])[0] = rslt.wasNull(33);
                return;
       }
    }

 }

}
