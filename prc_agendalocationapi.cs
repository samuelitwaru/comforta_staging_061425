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
   public class prc_agendalocationapi : GXProcedure
   {
      public prc_agendalocationapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_agendalocationapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ResidentId ,
                           string aP1_StartDateString ,
                           string aP2_EndDateString ,
                           out string aP3_SDT_AgendaLocationJson )
      {
         this.AV8ResidentId = aP0_ResidentId;
         this.AV20StartDateString = aP1_StartDateString;
         this.AV21EndDateString = aP2_EndDateString;
         this.AV12SDT_AgendaLocationJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_SDT_AgendaLocationJson=this.AV12SDT_AgendaLocationJson;
      }

      public string executeUdp( string aP0_ResidentId ,
                                string aP1_StartDateString ,
                                string aP2_EndDateString )
      {
         execute(aP0_ResidentId, aP1_StartDateString, aP2_EndDateString, out aP3_SDT_AgendaLocationJson);
         return AV12SDT_AgendaLocationJson ;
      }

      public void executeSubmit( string aP0_ResidentId ,
                                 string aP1_StartDateString ,
                                 string aP2_EndDateString ,
                                 out string aP3_SDT_AgendaLocationJson )
      {
         this.AV8ResidentId = aP0_ResidentId;
         this.AV20StartDateString = aP1_StartDateString;
         this.AV21EndDateString = aP2_EndDateString;
         this.AV12SDT_AgendaLocationJson = "" ;
         SubmitImpl();
         aP3_SDT_AgendaLocationJson=this.AV12SDT_AgendaLocationJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13SDT_AgendaLocationCollection = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         AV24GXLvl4 = 0;
         /* Using cursor P008H2 */
         pr_default.execute(0, new Object[] {AV8ResidentId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A71ResidentGUID = P008H2_A71ResidentGUID[0];
            A62ResidentId = P008H2_A62ResidentId[0];
            A29LocationId = P008H2_A29LocationId[0];
            A11OrganisationId = P008H2_A11OrganisationId[0];
            AV24GXLvl4 = 1;
            AV15AgendaResidentId = A62ResidentId;
            AV9LocationId = A29LocationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV24GXLvl4 == 0 )
         {
            AV13SDT_AgendaLocationCollection.Clear();
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20StartDateString)) )
         {
            AV18DateToStart = DateTimeUtil.DAdd( Gx_date, (-1));
         }
         else
         {
            AV22DateSplit = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV22DateSplit = GxRegex.Split(AV20StartDateString,"-");
            if ( ( AV22DateSplit.Count == 3 ) && ( StringUtil.Len( AV22DateSplit.GetString(1)) == 4 ) )
            {
               AV18DateToStart = context.localUtil.YMDToD( (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(1), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(2), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(3), "."), 18, MidpointRounding.ToEven)));
            }
            else
            {
               AV18DateToStart = DateTime.MinValue;
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21EndDateString)) )
         {
            AV19DateToEnd = DateTimeUtil.DAdd( Gx_date, (1));
         }
         else
         {
            AV22DateSplit = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV22DateSplit = GxRegex.Split(AV21EndDateString,"-");
            if ( ( AV22DateSplit.Count == 3 ) && ( StringUtil.Len( AV22DateSplit.GetString(1)) == 4 ) )
            {
               AV19DateToEnd = context.localUtil.YMDToD( (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(1), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(2), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( AV22DateSplit.GetString(3), "."), 18, MidpointRounding.ToEven)));
            }
            else
            {
               AV19DateToEnd = DateTime.MinValue;
            }
         }
         /* Using cursor P008H3 */
         pr_default.execute(1, new Object[] {AV15AgendaResidentId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A62ResidentId = P008H3_A62ResidentId[0];
            A268AgendaCalendarId = P008H3_A268AgendaCalendarId[0];
            AV14AgendaCalendaId = A268AgendaCalendarId;
            AV23AgendaCalendaIdCollection.Add(A268AgendaCalendarId, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P008H4 */
         pr_default.execute(2, new Object[] {AV9LocationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A268AgendaCalendarId = P008H4_A268AgendaCalendarId[0];
            A271AgendaCalendarEndDate = P008H4_A271AgendaCalendarEndDate[0];
            A270AgendaCalendarStartDate = P008H4_A270AgendaCalendarStartDate[0];
            A29LocationId = P008H4_A29LocationId[0];
            A269AgendaCalendarTitle = P008H4_A269AgendaCalendarTitle[0];
            A441AgendaCalendarType = P008H4_A441AgendaCalendarType[0];
            A272AgendaCalendarAllDay = P008H4_A272AgendaCalendarAllDay[0];
            A437AgendaCalendarRecurring = P008H4_A437AgendaCalendarRecurring[0];
            A438AgendaCalendarRecurringType = P008H4_A438AgendaCalendarRecurringType[0];
            A439AgendaCalendarAddRSVP = P008H4_A439AgendaCalendarAddRSVP[0];
            A11OrganisationId = P008H4_A11OrganisationId[0];
            A661AgendaCalendarLocationEvent = P008H4_A661AgendaCalendarLocationEvent[0];
            n661AgendaCalendarLocationEvent = P008H4_n661AgendaCalendarLocationEvent[0];
            if ( DateTimeUtil.ResetTime ( DateTimeUtil.ResetTime( A270AgendaCalendarStartDate) ) >= DateTimeUtil.ResetTime ( AV18DateToStart ) )
            {
               if ( DateTimeUtil.ResetTime ( DateTimeUtil.ResetTime( A271AgendaCalendarEndDate) ) <= DateTimeUtil.ResetTime ( AV19DateToEnd ) )
               {
                  AV10SDT_AgendaLocation = new SdtSDT_AgendaLocation(context);
                  AV10SDT_AgendaLocation.gxTpr_Agendacalendarid = A268AgendaCalendarId;
                  AV10SDT_AgendaLocation.gxTpr_Agendacalendartitle = A269AgendaCalendarTitle;
                  AV10SDT_AgendaLocation.gxTpr_Agendacalendartype = A441AgendaCalendarType;
                  AV10SDT_AgendaLocation.gxTpr_Agendacalendarstartdate = DateTimeUtil.TAdd( A270AgendaCalendarStartDate, 3600*(3));
                  AV10SDT_AgendaLocation.gxTpr_Agendacalendarenddate = DateTimeUtil.TAdd( A271AgendaCalendarEndDate, 3600*(3));
                  AV10SDT_AgendaLocation.gxTpr_Agendacalendarallday = A272AgendaCalendarAllDay;
                  AV10SDT_AgendaLocation.gxTpr_Agendacalendarrecurring = A437AgendaCalendarRecurring;
                  AV10SDT_AgendaLocation.gxTpr_Agendacalendarrecurringtype = A438AgendaCalendarRecurringType;
                  AV10SDT_AgendaLocation.gxTpr_Agendacalendaraddrsvp = A439AgendaCalendarAddRSVP;
                  AV10SDT_AgendaLocation.gxTpr_Locationid = A29LocationId;
                  AV10SDT_AgendaLocation.gxTpr_Organisationid = A11OrganisationId;
                  if ( A661AgendaCalendarLocationEvent )
                  {
                     AV13SDT_AgendaLocationCollection.Add(AV10SDT_AgendaLocation, 0);
                  }
                  else
                  {
                     /* Using cursor P008H5 */
                     pr_default.execute(3, new Object[] {A268AgendaCalendarId, AV15AgendaResidentId});
                     while ( (pr_default.getStatus(3) != 101) )
                     {
                        A62ResidentId = P008H5_A62ResidentId[0];
                        AV13SDT_AgendaLocationCollection.Add(AV10SDT_AgendaLocation, 0);
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(3);
                  }
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV12SDT_AgendaLocationJson = AV13SDT_AgendaLocationCollection.ToJSonString(false);
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
         AV12SDT_AgendaLocationJson = "";
         AV13SDT_AgendaLocationCollection = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         P008H2_A71ResidentGUID = new string[] {""} ;
         P008H2_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008H2_A29LocationId = new Guid[] {Guid.Empty} ;
         P008H2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A71ResidentGUID = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV15AgendaResidentId = Guid.Empty;
         AV9LocationId = Guid.Empty;
         AV18DateToStart = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV22DateSplit = new GxSimpleCollection<string>();
         AV19DateToEnd = DateTime.MinValue;
         P008H3_A62ResidentId = new Guid[] {Guid.Empty} ;
         P008H3_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         A268AgendaCalendarId = Guid.Empty;
         AV14AgendaCalendaId = Guid.Empty;
         AV23AgendaCalendaIdCollection = new GxSimpleCollection<Guid>();
         P008H4_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         P008H4_A271AgendaCalendarEndDate = new DateTime[] {DateTime.MinValue} ;
         P008H4_A270AgendaCalendarStartDate = new DateTime[] {DateTime.MinValue} ;
         P008H4_A29LocationId = new Guid[] {Guid.Empty} ;
         P008H4_A269AgendaCalendarTitle = new string[] {""} ;
         P008H4_A441AgendaCalendarType = new string[] {""} ;
         P008H4_A272AgendaCalendarAllDay = new bool[] {false} ;
         P008H4_A437AgendaCalendarRecurring = new bool[] {false} ;
         P008H4_A438AgendaCalendarRecurringType = new string[] {""} ;
         P008H4_A439AgendaCalendarAddRSVP = new bool[] {false} ;
         P008H4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P008H4_A661AgendaCalendarLocationEvent = new bool[] {false} ;
         P008H4_n661AgendaCalendarLocationEvent = new bool[] {false} ;
         A271AgendaCalendarEndDate = (DateTime)(DateTime.MinValue);
         A270AgendaCalendarStartDate = (DateTime)(DateTime.MinValue);
         A269AgendaCalendarTitle = "";
         A441AgendaCalendarType = "";
         A438AgendaCalendarRecurringType = "";
         AV10SDT_AgendaLocation = new SdtSDT_AgendaLocation(context);
         P008H5_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         P008H5_A62ResidentId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_agendalocationapi__default(),
            new Object[][] {
                new Object[] {
               P008H2_A71ResidentGUID, P008H2_A62ResidentId, P008H2_A29LocationId, P008H2_A11OrganisationId
               }
               , new Object[] {
               P008H3_A62ResidentId, P008H3_A268AgendaCalendarId
               }
               , new Object[] {
               P008H4_A268AgendaCalendarId, P008H4_A271AgendaCalendarEndDate, P008H4_A270AgendaCalendarStartDate, P008H4_A29LocationId, P008H4_A269AgendaCalendarTitle, P008H4_A441AgendaCalendarType, P008H4_A272AgendaCalendarAllDay, P008H4_A437AgendaCalendarRecurring, P008H4_A438AgendaCalendarRecurringType, P008H4_A439AgendaCalendarAddRSVP,
               P008H4_A11OrganisationId, P008H4_A661AgendaCalendarLocationEvent, P008H4_n661AgendaCalendarLocationEvent
               }
               , new Object[] {
               P008H5_A268AgendaCalendarId, P008H5_A62ResidentId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV24GXLvl4 ;
      private DateTime A271AgendaCalendarEndDate ;
      private DateTime A270AgendaCalendarStartDate ;
      private DateTime AV18DateToStart ;
      private DateTime Gx_date ;
      private DateTime AV19DateToEnd ;
      private bool A272AgendaCalendarAllDay ;
      private bool A437AgendaCalendarRecurring ;
      private bool A439AgendaCalendarAddRSVP ;
      private bool A661AgendaCalendarLocationEvent ;
      private bool n661AgendaCalendarLocationEvent ;
      private string AV12SDT_AgendaLocationJson ;
      private string AV8ResidentId ;
      private string AV20StartDateString ;
      private string AV21EndDateString ;
      private string A71ResidentGUID ;
      private string A269AgendaCalendarTitle ;
      private string A441AgendaCalendarType ;
      private string A438AgendaCalendarRecurringType ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV15AgendaResidentId ;
      private Guid AV9LocationId ;
      private Guid A268AgendaCalendarId ;
      private Guid AV14AgendaCalendaId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_AgendaLocation> AV13SDT_AgendaLocationCollection ;
      private IDataStoreProvider pr_default ;
      private string[] P008H2_A71ResidentGUID ;
      private Guid[] P008H2_A62ResidentId ;
      private Guid[] P008H2_A29LocationId ;
      private Guid[] P008H2_A11OrganisationId ;
      private GxSimpleCollection<string> AV22DateSplit ;
      private Guid[] P008H3_A62ResidentId ;
      private Guid[] P008H3_A268AgendaCalendarId ;
      private GxSimpleCollection<Guid> AV23AgendaCalendaIdCollection ;
      private Guid[] P008H4_A268AgendaCalendarId ;
      private DateTime[] P008H4_A271AgendaCalendarEndDate ;
      private DateTime[] P008H4_A270AgendaCalendarStartDate ;
      private Guid[] P008H4_A29LocationId ;
      private string[] P008H4_A269AgendaCalendarTitle ;
      private string[] P008H4_A441AgendaCalendarType ;
      private bool[] P008H4_A272AgendaCalendarAllDay ;
      private bool[] P008H4_A437AgendaCalendarRecurring ;
      private string[] P008H4_A438AgendaCalendarRecurringType ;
      private bool[] P008H4_A439AgendaCalendarAddRSVP ;
      private Guid[] P008H4_A11OrganisationId ;
      private bool[] P008H4_A661AgendaCalendarLocationEvent ;
      private bool[] P008H4_n661AgendaCalendarLocationEvent ;
      private SdtSDT_AgendaLocation AV10SDT_AgendaLocation ;
      private Guid[] P008H5_A268AgendaCalendarId ;
      private Guid[] P008H5_A62ResidentId ;
      private string aP3_SDT_AgendaLocationJson ;
   }

   public class prc_agendalocationapi__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008H2;
          prmP008H2 = new Object[] {
          new ParDef("AV8ResidentId",GXType.VarChar,100,60)
          };
          Object[] prmP008H3;
          prmP008H3 = new Object[] {
          new ParDef("AV15AgendaResidentId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008H4;
          prmP008H4 = new Object[] {
          new ParDef("AV9LocationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP008H5;
          prmP008H5 = new Object[] {
          new ParDef("AgendaCalendarId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV15AgendaResidentId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008H2", "SELECT ResidentGUID, ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentGUID = ( :AV8ResidentId) ORDER BY ResidentId, LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008H2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008H3", "SELECT ResidentId, AgendaCalendarId FROM Trn_AgendaEventGroup WHERE ResidentId = :AV15AgendaResidentId ORDER BY AgendaCalendarId, ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008H3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008H4", "SELECT AgendaCalendarId, AgendaCalendarEndDate, AgendaCalendarStartDate, LocationId, AgendaCalendarTitle, AgendaCalendarType, AgendaCalendarAllDay, AgendaCalendarRecurring, AgendaCalendarRecurringType, AgendaCalendarAddRSVP, OrganisationId, AgendaCalendarLocationEvent FROM Trn_AgendaCalendar WHERE LocationId = :AV9LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008H4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008H5", "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = :AgendaCalendarId and ResidentId = :AV15AgendaResidentId ORDER BY AgendaCalendarId, ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008H5,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((Guid[]) buf[10])[0] = rslt.getGuid(11);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
