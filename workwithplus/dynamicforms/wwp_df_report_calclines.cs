using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class wwp_df_report_calclines : GXProcedure
   {
      public wwp_df_report_calclines( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_report_calclines( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_text ,
                           string aP1_TextType ,
                           out short aP2_Lines )
      {
         this.AV8text = aP0_text;
         this.AV13TextType = aP1_TextType;
         this.AV9Lines = 0 ;
         initialize();
         ExecuteImpl();
         aP2_Lines=this.AV9Lines;
      }

      public short executeUdp( string aP0_text ,
                               string aP1_TextType )
      {
         execute(aP0_text, aP1_TextType, out aP2_Lines);
         return AV9Lines ;
      }

      public void executeSubmit( string aP0_text ,
                                 string aP1_TextType ,
                                 out short aP2_Lines )
      {
         this.AV8text = aP0_text;
         this.AV13TextType = aP1_TextType;
         this.AV9Lines = 0 ;
         SubmitImpl();
         aP2_Lines=this.AV9Lines;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10MaxCharacters = 100;
         if ( StringUtil.StrCmp(AV13TextType, "Label_left") == 0 )
         {
            AV10MaxCharacters = 31;
         }
         else if ( StringUtil.StrCmp(AV13TextType, "Label_entire_line") == 0 )
         {
            AV10MaxCharacters = 83;
         }
         else if ( StringUtil.StrCmp(AV13TextType, "Title") == 0 )
         {
            AV10MaxCharacters = 75;
         }
         else if ( StringUtil.StrCmp(AV13TextType, "Data_right") == 0 )
         {
            AV10MaxCharacters = 54;
         }
         else if ( StringUtil.StrCmp(AV13TextType, "Data_entire_line") == 0 )
         {
            AV10MaxCharacters = 92;
         }
         AV12textAux = StringUtil.Trim( AV8text);
         AV15GXV2 = 1;
         AV14GXV1 = GxRegex.Split(AV12textAux,StringUtil.Chr( 10));
         while ( AV15GXV2 <= AV14GXV1.Count )
         {
            AV11VarCharAux = AV14GXV1.GetString(AV15GXV2);
            AV9Lines = (short)(AV9Lines+(1+(StringUtil.Len( StringUtil.Trim( AV11VarCharAux))/ (decimal)(AV10MaxCharacters))));
            AV15GXV2 = (int)(AV15GXV2+1);
         }
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
         AV12textAux = "";
         AV14GXV1 = new GxSimpleCollection<string>();
         AV11VarCharAux = "";
         /* GeneXus formulas. */
      }

      private short AV9Lines ;
      private short AV10MaxCharacters ;
      private int AV15GXV2 ;
      private string AV8text ;
      private string AV13TextType ;
      private string AV12textAux ;
      private string AV11VarCharAux ;
      private GxSimpleCollection<string> AV14GXV1 ;
      private short aP2_Lines ;
   }

}
