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
   public class wwp_df_import : GXProcedure
   {
      public wwp_df_import( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_import( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_FilePath ,
                           bool aP1_Overwrite ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ,
                           out bool aP3_IsOk )
      {
         this.AV9FilePath = aP0_FilePath;
         this.AV12Overwrite = aP1_Overwrite;
         this.AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV10IsOk = false ;
         initialize();
         ExecuteImpl();
         aP2_Messages=this.AV11Messages;
         aP3_IsOk=this.AV10IsOk;
      }

      public bool executeUdp( string aP0_FilePath ,
                              bool aP1_Overwrite ,
                              out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         execute(aP0_FilePath, aP1_Overwrite, out aP2_Messages, out aP3_IsOk);
         return AV10IsOk ;
      }

      public void executeSubmit( string aP0_FilePath ,
                                 bool aP1_Overwrite ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ,
                                 out bool aP3_IsOk )
      {
         this.AV9FilePath = aP0_FilePath;
         this.AV12Overwrite = aP1_Overwrite;
         this.AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV10IsOk = false ;
         SubmitImpl();
         aP2_Messages=this.AV11Messages;
         aP3_IsOk=this.AV10IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10IsOk = true;
         AV8File.Source = AV9FilePath;
         AV10IsOk = AV13WWPForm.FromJSonFile(AV8File, null);
         if ( AV10IsOk )
         {
            GXt_boolean1 = AV20UniqueReferenceName;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context ).execute(  0,  AV13WWPForm.gxTpr_Wwpformreferencename, out  GXt_boolean1) ;
            AV20UniqueReferenceName = GXt_boolean1;
            if ( AV20UniqueReferenceName )
            {
               /* Using cursor P00502 */
               pr_default.execute(0);
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A206WWPFormId = P00502_A206WWPFormId[0];
                  A207WWPFormVersionNumber = P00502_A207WWPFormVersionNumber[0];
                  AV13WWPForm.gxTpr_Wwpformid = A206WWPFormId;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               AV13WWPForm.gxTpr_Wwpformid = (short)(AV13WWPForm.gxTpr_Wwpformid+1);
               AV13WWPForm.gxTpr_Wwpformversionnumber = 1;
               AV13WWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
               AV13WWPForm.Insert();
               /* Execute user subroutine: 'EVALUATEANDCOMMITFORM' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else
            {
               if ( AV12Overwrite )
               {
                  /* Using cursor P00503 */
                  pr_default.execute(1, new Object[] {AV13WWPForm.gxTpr_Wwpformreferencename});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A208WWPFormReferenceName = P00503_A208WWPFormReferenceName[0];
                     A206WWPFormId = P00503_A206WWPFormId[0];
                     A234WWPFormInstantiated = P00503_A234WWPFormInstantiated[0];
                     A231WWPFormDate = P00503_A231WWPFormDate[0];
                     A207WWPFormVersionNumber = P00503_A207WWPFormVersionNumber[0];
                     AV14WWPFormId = A206WWPFormId;
                     AV16WWPFormVersionNumber = A207WWPFormVersionNumber;
                     AV19FormWasInstantiated = A234WWPFormInstantiated;
                     AV17WWPFormDate = A231WWPFormDate;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     pr_default.readNext(1);
                  }
                  pr_default.close(1);
                  if ( AV19FormWasInstantiated )
                  {
                     AV15NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
                     AV15NewWWPForm.gxTpr_Wwpformid = AV14WWPFormId;
                     AV15NewWWPForm.gxTpr_Wwpformversionnumber = (short)(AV16WWPFormVersionNumber+1);
                     AV15NewWWPForm.gxTpr_Wwpformreferencename = AV13WWPForm.gxTpr_Wwpformreferencename;
                  }
                  else
                  {
                     AV15NewWWPForm.Load(AV14WWPFormId, AV16WWPFormVersionNumber);
                     AV15NewWWPForm.gxTpr_Element.Clear();
                     AV15NewWWPForm.gxTpr_Element.Sort("(WWPFormElementId)");
                     AV15NewWWPForm.Save();
                  }
                  AV15NewWWPForm.gxTpr_Wwpformtitle = AV13WWPForm.gxTpr_Wwpformtitle;
                  AV15NewWWPForm.gxTpr_Wwpformiswizard = AV13WWPForm.gxTpr_Wwpformiswizard;
                  AV15NewWWPForm.gxTpr_Wwpformvalidations = AV13WWPForm.gxTpr_Wwpformvalidations;
                  AV15NewWWPForm.gxTpr_Wwpformresume = AV13WWPForm.gxTpr_Wwpformresume;
                  AV15NewWWPForm.gxTpr_Wwpformresumemessage = AV13WWPForm.gxTpr_Wwpformresumemessage;
                  AV23GXV1 = 1;
                  while ( AV23GXV1 <= AV13WWPForm.gxTpr_Element.Count )
                  {
                     AV18Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV13WWPForm.gxTpr_Element.Item(AV23GXV1));
                     if ( AV18Element.gxTpr_Wwpformelementparentid >= 0 )
                     {
                        AV15NewWWPForm.gxTpr_Element.Add(AV18Element, 0);
                     }
                     AV23GXV1 = (int)(AV23GXV1+1);
                  }
                  AV13WWPForm = AV15NewWWPForm;
                  AV13WWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
                  AV13WWPForm.Save();
                  /* Execute user subroutine: 'EVALUATEANDCOMMITFORM' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
               else
               {
                  AV10IsOk = false;
                  new WorkWithPlus.workwithplus_web.wwp_addmessage(context ).execute(  "WWP_DF_Import_ReferenceExistentTitle",  1,  context.GetMessage( "WWP_DF_Import_ReferenceExistent", ""), ref  AV11Messages) ;
               }
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'EVALUATEANDCOMMITFORM' Routine */
         returnInSub = false;
         if ( AV13WWPForm.Success() )
         {
            context.CommitDataStores("workwithplus.dynamicforms.wwp_df_import",pr_default);
         }
         else
         {
            new WorkWithPlus.workwithplus_web.wwp_addimporterrormessages(context ).execute( ref  AV11Messages,  "",  AV13WWPForm.GetMessages()) ;
            AV10IsOk = false;
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
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8File = new GxFile(context.GetPhysicalPath());
         AV13WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         P00502_A206WWPFormId = new short[1] ;
         P00502_A207WWPFormVersionNumber = new short[1] ;
         P00503_A208WWPFormReferenceName = new string[] {""} ;
         P00503_A206WWPFormId = new short[1] ;
         P00503_A234WWPFormInstantiated = new bool[] {false} ;
         P00503_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00503_A207WWPFormVersionNumber = new short[1] ;
         A208WWPFormReferenceName = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         AV17WWPFormDate = (DateTime)(DateTime.MinValue);
         AV15NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV18Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_import__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_import__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_import__default(),
            new Object[][] {
                new Object[] {
               P00502_A206WWPFormId, P00502_A207WWPFormVersionNumber
               }
               , new Object[] {
               P00503_A208WWPFormReferenceName, P00503_A206WWPFormId, P00503_A234WWPFormInstantiated, P00503_A231WWPFormDate, P00503_A207WWPFormVersionNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short AV14WWPFormId ;
      private short AV16WWPFormVersionNumber ;
      private int AV23GXV1 ;
      private DateTime A231WWPFormDate ;
      private DateTime AV17WWPFormDate ;
      private bool AV12Overwrite ;
      private bool AV10IsOk ;
      private bool AV20UniqueReferenceName ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool A234WWPFormInstantiated ;
      private bool AV19FormWasInstantiated ;
      private string AV9FilePath ;
      private string A208WWPFormReferenceName ;
      private GxFile AV8File ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV13WWPForm ;
      private IDataStoreProvider pr_default ;
      private short[] P00502_A206WWPFormId ;
      private short[] P00502_A207WWPFormVersionNumber ;
      private string[] P00503_A208WWPFormReferenceName ;
      private short[] P00503_A206WWPFormId ;
      private bool[] P00503_A234WWPFormInstantiated ;
      private DateTime[] P00503_A231WWPFormDate ;
      private short[] P00503_A207WWPFormVersionNumber ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV15NewWWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV18Element ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
      private bool aP3_IsOk ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_df_import__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_df_import__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_df_import__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmP00502;
       prmP00502 = new Object[] {
       };
       Object[] prmP00503;
       prmP00503 = new Object[] {
       new ParDef("AV13WWPF_1Wwpformreferencenam",GXType.VarChar,100,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00502", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form ORDER BY WWPFormId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00502,1, GxCacheFrequency.OFF ,false,true )
          ,new CursorDef("P00503", "SELECT WWPFormReferenceName, WWPFormId, WWPFormInstantiated, WWPFormDate, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormReferenceName = ( :AV13WWPF_1Wwpformreferencenam) ORDER BY WWPFormReferenceName, WWPFormVersionNumber DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00503,1, GxCacheFrequency.OFF ,false,true )
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
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             return;
    }
 }

}

}
