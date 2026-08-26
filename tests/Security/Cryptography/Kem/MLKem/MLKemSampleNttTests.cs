// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Kem.MLKem;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using CryptoHives.Foundation.Security.Cryptography.Kem;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for <c>Poly.SampleNtt</c>, FIPS 203 Algorithm 6, with emphasis on its re-squeeze path.
/// </summary>
/// <remarks>
/// <para>
/// <c>SampleNtt</c> squeezes 504 bytes from SHAKE128 and loops when rejection sampling comes up
/// short of 256 coefficients. 504 bytes yields 336 candidate 12-bit values at an acceptance
/// rate of 3329/4096, so the expected yield is about 273 with a standard deviation near 7.1 --
/// a second squeeze is needed for roughly 0.7% of polynomials. The path is therefore reached
/// often enough to matter (about 11% of ML-KEM-1024 key generations, which sample 16 matrix
/// entries) and rarely enough that nothing deterministic pinned it.
/// </para>
/// <para>
/// This is the classic latent defect in ML-KEM implementations: if the XOF restarts its stream
/// on the second squeeze instead of continuing it, the sampled matrix silently diverges. A
/// regression would be intermittent and easily blamed elsewhere, so the seeds below are chosen
/// to force the path deterministically.
/// </para>
/// <para>
/// Expected coefficients come from an independent Python reference driven by
/// <c>hashlib.shake_128</c>, taking the stream as a single <c>digest(1008)</c> -- which is by
/// definition squeeze(504) followed by squeeze(504). The seeds were found by scanning
/// (rho, i, j) triples for a first-block yield below 256; see
/// <c>scripts/fetch-mlkem-acvp-vectors.py</c>'s sibling note in the issue for provenance.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MLKemSampleNttTests
{
    /// <summary>
    /// Seeds whose first 504-byte squeeze accepts fewer than 256 coefficients, forcing a second
    /// squeeze: seed, first-block yield, squeezes required, expected coefficients.
    /// </summary>
    private static readonly object[] ReSqueezeVectors =
    [
            new object[] { "03000000000000000000000000000000000000000000000000000000000000000203", 254, 2, "04DD09300AAB057C074D0B8D08C30C660A9805FF0B6B000D0AFC06AB09910B2203EE00D1006F04EC034703310837057C03540A380581047B046F03F907E50AD707F20B6C038603600C74064401D0024C074801D4055902B30192043C081E00BC09190157001809F803CE01F0021E02F104610990018806390A7302A7081106A7016200850A9E049904C7007606E00BB20CF70AB103C70A2108DA00DA0CBE0B690C3900D3036601E50ADC04060BF800EF0BF101AE0C5E0CA70C15056B0CDF091A009205490CA30665042102490274012D030603FF056106BE04BB007B0AF2094F0C0D0C8C01620CA907A501B602A000B705370041070900A40124018C036206A506AE0C590AA801EA05C5085308E60C710B7904F40A1108CB052A021B0CC60B3409E805750CB60B9B05CF00EB0207076D084A01500AF70617052304F30375015C04030A460AE106B707CB0442002503900911098F0BC2026A004F01D200B1078101310C1A05FD07EA04BB04110C2405340C7004F800C90CC50B9B05E808E4048403830607011205A30A5D0863007905EC041C0A7F00D400F10779081F0865083202A101E003770B070AC50B6C0AAE00A40682044D070F02A706FD0CF50642044101440602025D0A17031806F70AB80ACE08F202B905A80B40089800C00ABD070300130985045707E80A8100EB0CC708010A1303A703A4069D032D08550A06051E" },
            new object[] { "07000000000000000000000000000000000000000000000000000000000000000000", 250, 2, "01C80A1F092C0AAC01C703570CFB08DC07C604EA029F0B010ACB036E00A605E4095209C90CBE032B01E70BA909C40C7D03F70C6A08960C970C2A029D061905B001E9098B03B90C750B8403F30296021D0688082108900BC702E70828029B03DA0A6D00B60C9A037C0CDC08C4079B0C7608CC029D06B9013E04F9082C08A00073025108D202ED001907BD048F039508A3010700AA0C2605FD064304C40285085A04D604D90783045804840309067006490C0603AC0374045F09DD087005C4086D048608D7083D09D40C5D01350B6A00B0096B04B20AB804A507DE06750A2D020D098C07D403880B4B0473023300DF088E0AF705FE057B0A790368087B05ED03A501EA090A0735043D04B608020BA50CF103F600C9045F074A08D905FE0BCD015008E30A5B011605EB0C0106E70066088C05C10AB90C97087001230B5D080307CE04370464094806D40670078705B9052905240B8107660902036708BB03AB02A006FA01CE02AA02BB027B02710A0802150C000AC207780C53042803910BEB09450256038A0502049A04220A11031D0C3007A001ED091C0B6A096304E502A202A002E8069E0C13037D074603F401AE05E50463099002920CD40CC909FF04FE0859001D0C820C5F0898073E033304BA04D108320CD506C7081F008808A305E0058904AC0CCA01F605BC0135061B07D901D401D807CA0B8D05B703A00C9409F30B78" },
            new object[] { "08000000000000000000000000000000000000000000000000000000000000000002", 253, 2, "0B0C0B12064B0CE1058B095809F10408036906DB03C50080017901EA0BCA042C007D006804D80A73089B017A04150A1601F60BFE0C5400D90954047401B30B3C0A2F04A50CA70AFF0288099E07D2033705AF010F0A28026700B306180CFE03A10CCB03370768085D071A086B016D08BD0C9F015800D200AA082006490B8D093500790782094D0C5F0353039E015100790AA007FF03A005B503490C21008E0A470B9903350C45009202CB0127058200DC0A890309018706AC0ACF092E05390CA8014A0C5406E107A002C30B950BDE01CB0BBD067606FC00180751031003E2079A080401C905390BE207460046065100030C44088F0AA70C7A03240B1E035002BA08340431086309EE07E609FE0733089F09FF09D602BA011E07FA0429011D0805077305E7045507E30C2E094D0C7C08E509E5013F040A068E09D4070504E2043B098F09AD046A0BF209E9091F02630C69013909CE0CE00830019807AA022903BE0B4A0A88006E0279073D06500C11092A04260991024E0BD503700259017A07CE049908D20598026109E9067903FE03F400CB02B20CD5086A0A2004360A2C00F1028E09F601F809700022063C037004DC01A5001F04620707047503B70C0508E004D6087803D9028C0BB20B17033D08CD0B1009790866078209910899046607940090037D0456043806720A1902520571073F066409B70B2C059E0A2902AE09C9" },
            new object[] { "0D000000000000000000000000000000000000000000000000000000000000000001", 253, 2, "00F80B7605D70CC909E0075A09A206FD01760B810A9B0BCA011100720674023D0BDC0C710B86059F07AD08EB055E00BF0B3806B6041E01480A72035C0171044605C30B4D09090AF7046D05780C55052C03B0060E0765027A035B0C4D04850797056F07250C290641066A0552031B0A63080D07560CD70BE50BF50A33051501AA039600CB044D078B095809350C950202075007700A03082902FB0ACD00F50BCB056C015A0AAB0B4A0B0708AF0A0D006503BE05B001AC0CF804B205FE0089070B0A5404950128019F0B7F00A80C6C025A0C5C03A4030A0229007909E304280087052E0AC105EC004706EF0C730B0002B405760617088109630A610861094602D502BA0CAB01D107AB03D4064808B0079D001301D109280B38027A09ED00C90A3E09C505D80A470AFD022709D100720C56012E059F04C5016D08F8084003B00C9D08C50A9A01DF024D003D0C3C06EF014701310000087B03DB06BD01010A9807DC0B0500E700240B5A057B02560B9108D70295072C0A10082306640A5D0098049B0372067D0C6B011E08C0091C05E70148067A0110081005D206FB097B0C5104C403BB03B3021107EE070509AE019506A608C90BA109B8014E05840A9801AD086601F00C580ABF00B5042304D50C8D07E5053E0B4D050C0A5B025F05FA06BB010A0C3602FC046A018F0C590931078C02BD023007C1019D03D50208047906DE0294" },
    ];

    /// <summary>
    /// Seeds satisfied by a single squeeze, as a control: seed, first-block yield, squeezes
    /// required, expected coefficients.
    /// </summary>
    private static readonly object[] SingleSqueezeVectors =
    [
            new object[] { "00000000000000000000000000000000000000000000000000000000000000000000", 271, 1, "0B800BC9015404A00CAB06AC099A08ED0AD40957019D010207290601089B0A780C6206D50AA9010A042E02E304D50419055608B80B9C05BC05F70799059F0A160A9708A100BC0C7C0C9E0529098B04660056011E006B037600750A950B2A0541065201820C5A06C602C809F402C50B100C8508250B55024509A40893095B082D07470BD406170C6C07F30924090D04A5050805050899017C09B5092C0B7C091602D404BE01DB0C50048D0C20001507E2064303480A5001FB00A904C103EA0B5D007F0309073D013808AC051F064309BA05740CDC02D501A1084C036305970C01029D053600C8052C0A23072F06AE02AD0C820105057201AF0B8F05A8011209B601760690042C0007037A0BB407D9059400BC0141025C07BF09700168029504CE0B070180013D094E0BAA0A5402FD07B10B07050A09030244014B0A150BB00B9F09610C1308850BDF071C0CBB039806660712021A06C90BC70834092906AA0A2C0AC0048001F303DD02290C54013A097909D407EF00C707F50B6A02330A8E009F09730B0D091B0C5503C708A3095800FD0786057E05E90AC105EC086600BC0A6405430808018F0A6E0755093A048104F20012053F0B4A0B030826054C0101096803F20A87018808E2062508CE09DE0CDA0040060C0B9300780C7B0B50053B09A1066D0C5E099607C707B3071D034706B9070203DF07AA07BD0C970AC101630813" },
            new object[] { "00000000000000000000000000000000000000000000000000000000000000000001", 271, 1, "0CA4004D014003DF097F0BF805BF0267052D080C082707A1059B01D203CE0727065003090CAE07E9027F059002D50829047F00EE009300F709A40CC600CC04470589036D03D8012405CC050D01C30C4604C50A2501CA04B701F208BD0BE3085400E900C40A8B046A093A05180B590165091A0195077D07AD08970A3404B50AE909F60CEE092903B706230C6007BE080E0A43097F00460C870B0207760A1105F50BC20B670AB009FD0169021603190501085404B800C5038906CD0CCA00DF09870A1502E105B6013E093D02F202A301B706DB08F80B3C01D70CB70C27052F0B18053A02E00503061003E802BC06EB09650CC9013600CB0A7E037004CD065C0C19063F016306CB0738026E043305AE023A0063072606A0074A059C0C09083D0B6A088908460BE304D808FD05320067051007EF0BC906D40923038A0A920B1C014804D10C900B1A094E060703C20BD002E4062D0C9105E004E107A002F506070AA80CD40564047203160C610A21025904AD0144012302C104900B22061706BB0C26021504170298056D026C08C906D6099403B8059803CB085A091301E10AF905700564019F0BFB0970096D085A01B702D305BB01480269027402CB04AD03F707220A6B032A0C29069304A209B802470CFD002B0BD00CEC0A3D0A0008670B60097209F40BE10BE903540AB80137087105BA099406970CD9019B0B630CEC010008BE" },
    ];

    /// <summary>
    /// Verifies that seeds requiring a second squeeze sample correctly, i.e. that the XOF
    /// continues its stream rather than restarting it.
    /// </summary>
    /// <param name="seedHex">The 34-byte seed (rho, i, j).</param>
    /// <param name="firstBlockYield">Coefficients accepted from the first 504-byte block.</param>
    /// <param name="squeezes">Number of squeezes the seed requires.</param>
    /// <param name="expectedHex">The expected 256 coefficients, big-endian per coefficient.</param>
    [Test]
    [TestCaseSource(nameof(ReSqueezeVectors))]
    public void SampleNtt_ReSqueezePath_MatchesReference(string seedHex, int firstBlockYield, int squeezes, string expectedHex)
    {
        Assert.That(squeezes, Is.EqualTo(2), "vector is mislabelled: it does not require a second squeeze");
        Assert.That(firstBlockYield, Is.LessThan(256), "vector is mislabelled: the first block already suffices");

        AssertSamples(seedHex, expectedHex);
    }

    /// <summary>
    /// Control: seeds satisfied by one squeeze must sample correctly too, so a failure in the
    /// re-squeeze cases points at the second squeeze rather than at sampling in general.
    /// </summary>
    /// <param name="seedHex">The 34-byte seed (rho, i, j).</param>
    /// <param name="firstBlockYield">Coefficients accepted from the first 504-byte block.</param>
    /// <param name="squeezes">Number of squeezes the seed requires.</param>
    /// <param name="expectedHex">The expected 256 coefficients, big-endian per coefficient.</param>
    [Test]
    [TestCaseSource(nameof(SingleSqueezeVectors))]
    public void SampleNtt_SingleSqueezePath_MatchesReference(string seedHex, int firstBlockYield, int squeezes, string expectedHex)
    {
        Assert.That(squeezes, Is.EqualTo(1), "vector is mislabelled: it requires a second squeeze");
        Assert.That(firstBlockYield, Is.GreaterThanOrEqualTo(256), "vector is mislabelled: the first block does not suffice");

        AssertSamples(seedHex, expectedHex);
    }

    /// <summary>
    /// Verifies that a squeeze split across two calls is byte-identical to one large squeeze.
    /// </summary>
    /// <remarks>
    /// This is the underlying property <c>SampleNtt</c>'s loop depends on, asserted directly on
    /// the XOF so a failure separates "the sponge does not continue" from "the sampler
    /// mishandles the second block".
    /// </remarks>
    [Test]
    public void Shake128_SplitSqueezeMatchesSingleSqueeze()
    {
        byte[] seed = MLKemAcvpVectors.FromHex(
            "03000000000000000000000000000000000000000000000000000000000000000203");

        byte[] combined = new byte[2 * 504];
        using (var xof = new Shake128())
        {
            xof.Absorb(seed);
            xof.Squeeze(combined);
        }

        byte[] split = new byte[2 * 504];
        using (var xof = new Shake128())
        {
            xof.Absorb(seed);
            xof.Squeeze(split.AsSpan(0, 504));
            xof.Squeeze(split.AsSpan(504, 504));
        }

        Assert.That(split, Is.EqualTo(combined));
    }

    /// <summary>
    /// Verifies that every coefficient produced for a re-squeeze seed is a valid residue, which
    /// a stream restart would not reliably violate but a framing error would.
    /// </summary>
    [Test]
    public void SampleNtt_ProducesCanonicalResidues()
    {
        foreach (object[] vector in ReSqueezeVectors)
        {
            short[] coeffs = Sample((string)vector[0]);

            foreach (short coefficient in coeffs)
            {
                Assert.That(coefficient, Is.InRange((short)0, (short)3328),
                    $"seed {vector[0]}: coefficient outside [0, q)");
            }
        }
    }

    /// <summary>
    /// Samples a polynomial and compares it against the reference coefficients.
    /// </summary>
    /// <param name="seedHex">The 34-byte seed.</param>
    /// <param name="expectedHex">The expected coefficients.</param>
    private static void AssertSamples(string seedHex, string expectedHex)
    {
        short[] actual = Sample(seedHex);

        short[] expected = new short[256];
        for (int i = 0; i < expected.Length; i++)
        {
            expected[i] = (short)Convert.ToUInt16(expectedHex.Substring(i * 4, 4), 16);
        }

        Assert.That(actual, Is.EqualTo(expected), $"seed {seedHex}: sampled polynomial mismatch");
    }

    /// <summary>
    /// Runs <c>Poly.SampleNtt</c> for one seed.
    /// </summary>
    /// <param name="seedHex">The 34-byte seed.</param>
    /// <returns>The sampled coefficients.</returns>
    private static short[] Sample(string seedHex)
    {
        byte[] seed = MLKemAcvpVectors.FromHex(seedHex);
        short[] coeffs = new short[256];

        using var xof = new Shake128();
        Poly.SampleNtt(xof, seed, coeffs);

        return coeffs;
    }
}
