window.BENCHMARK_DATA = {
  "lastUpdate": 1777507146945,
  "repoUrl": "https://github.com/CryptoHives/Foundation",
  "entries": {
    "Threading": [
      {
        "commit": {
          "author": {
            "name": "The Keeper of the Crypto Hives",
            "username": "cryptohivekeeper",
            "email": "235137155+cryptohivekeeper@users.noreply.github.com"
          },
          "committer": {
            "name": "GitHub",
            "username": "web-flow",
            "email": "noreply@github.com"
          },
          "id": "d6857398018de90d1d17f1e5d5f07605b3136d0b",
          "message": "Fix Benchmarks CI (#145)\n\nSigned-off-by: The Keeper of the Crypto Hives <235137155+cryptohivekeeper@users.noreply.github.com>\nCo-authored-by: Crypto Drone <235138851+cryptodrone365@users.noreply.github.com>",
          "timestamp": "2026-04-29T20:42:33Z",
          "url": "https://github.com/CryptoHives/Foundation/commit/d6857398018de90d1d17f1e5d5f07605b3136d0b"
        },
        "date": 1777507145934,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetBenchmark.ProtoPromiseAsyncAutoResetEventSet",
            "value": 1.011090599000454,
            "unit": "ns",
            "range": "± 0.003885981262627994"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetBenchmark.PooledAsyncAutoResetEventSet",
            "value": 1.237332969903946,
            "unit": "ns",
            "range": "± 0.019666801188277523"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetBenchmark.NitoAsyncAutoResetEventSet",
            "value": 9.482582608503956,
            "unit": "ns",
            "range": "± 0.021012298705995462"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetBenchmark.RefImplAsyncAutoResetEventSet",
            "value": 10.552054441892183,
            "unit": "ns",
            "range": "± 0.02523182692039639"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetBenchmark.AutoResetEventSet",
            "value": 98.78690014894192,
            "unit": "ns",
            "range": "± 0.3028234839162363"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetThenWaitBenchmark.ProtoPromiseAsyncAutoResetEventSetThenWaitAsync",
            "value": 10.305697268495956,
            "unit": "ns",
            "range": "± 0.02271922340696291"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetThenWaitBenchmark.PooledAsTaskAsyncAutoResetEventSetThenWaitAsync",
            "value": 13.918544131975908,
            "unit": "ns",
            "range": "± 0.01775702653005364"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetThenWaitBenchmark.PooledAsyncAutoResetEventSetThenWaitAsync",
            "value": 14.329521713512284,
            "unit": "ns",
            "range": "± 0.020285991069348006"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetThenWaitBenchmark.NitoAsyncAutoResetEventSetThenWaitAsync",
            "value": 28.399364347641285,
            "unit": "ns",
            "range": "± 0.051086607579321666"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventSetThenWaitBenchmark.RefImplAsyncAutoResetEventSetThenWaitAsync",
            "value": 31.67494331414883,
            "unit": "ns",
            "range": "± 0.05095543726819473"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 45.0565609060801,
            "unit": "ns",
            "range": "± 0.047848690097430965"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 45.29324943744219,
            "unit": "ns",
            "range": "± 0.02765470206066619"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.ProtoPromiseAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 46.887264426265446,
            "unit": "ns",
            "range": "± 0.06771984728910135"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 52.48599576155345,
            "unit": "ns",
            "range": "± 0.19078857074600125"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 52.873623920338495,
            "unit": "ns",
            "range": "± 0.12756155785313641"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.RefImplAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 65.97815630435943,
            "unit": "ns",
            "range": "± 0.5842297060581192"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskContSyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 72.91876974105836,
            "unit": "ns",
            "range": "± 0.45583539719578614"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.NitoAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 83.27542765651431,
            "unit": "ns",
            "range": "± 0.8146618768077354"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 957.6742603373978,
            "unit": "ns",
            "range": "± 39.51166838067016"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 77.06535430749257,
            "unit": "ns",
            "range": "± 1.2552385516049334"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 80.71303362846375,
            "unit": "ns",
            "range": "± 1.4201759144491333"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 80.9633421599865,
            "unit": "ns",
            "range": "± 0.20701531755051933"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 82.70440021355947,
            "unit": "ns",
            "range": "± 0.6434934754938151"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.ProtoPromiseAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 88.21848562955856,
            "unit": "ns",
            "range": "± 0.35922431822567713"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskContSyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 115.91879950960477,
            "unit": "ns",
            "range": "± 0.23437191753254807"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.NitoAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 471.33534013657345,
            "unit": "ns",
            "range": "± 10.979503767678052"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 1083.3538845777512,
            "unit": "ns",
            "range": "± 17.344180813530695"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.ProtoPromiseAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 90.5531155879681,
            "unit": "ns",
            "range": "± 0.15372538199466776"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 111.94674594402314,
            "unit": "ns",
            "range": "± 0.7645321282258493"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 114.39009535710017,
            "unit": "ns",
            "range": "± 0.9634585359874613"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 125.12139421242934,
            "unit": "ns",
            "range": "± 0.14528133736429125"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.RefImplAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 125.25657873153686,
            "unit": "ns",
            "range": "± 0.9015817965038665"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 135.46784053530013,
            "unit": "ns",
            "range": "± 0.735328014436519"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.NitoAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 173.24621415138245,
            "unit": "ns",
            "range": "± 0.797406090439184"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskContSyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 181.01274288617648,
            "unit": "ns",
            "range": "± 0.7510576048095563"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 1590.682521724701,
            "unit": "ns",
            "range": "± 51.9556059813209"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.ProtoPromiseAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 180.645957836738,
            "unit": "ns",
            "range": "± 0.23281398165871664"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 184.2190409047263,
            "unit": "ns",
            "range": "± 0.18501314414480222"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 186.80485892295837,
            "unit": "ns",
            "range": "± 2.032496486957927"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 190.3691929658254,
            "unit": "ns",
            "range": "± 3.474220288989722"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 192.161700963974,
            "unit": "ns",
            "range": "± 3.758370009447767"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskContSyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 259.5528523004972,
            "unit": "ns",
            "range": "± 1.935335823980604"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.NitoAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 852.3341632843018,
            "unit": "ns",
            "range": "± 7.250118940042733"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 1613.6889345986503,
            "unit": "ns",
            "range": "± 18.331227540180322"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.ProtoPromiseAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 461.7121737798055,
            "unit": "ns",
            "range": "± 5.220602951820609"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 609.904969555991,
            "unit": "ns",
            "range": "± 8.845595867621483"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 628.9185272216797,
            "unit": "ns",
            "range": "± 9.097245147511499"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.RefImplAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 648.7762269973755,
            "unit": "ns",
            "range": "± 3.672806206537206"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 652.841628074646,
            "unit": "ns",
            "range": "± 6.154001971789899"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 746.1012900034586,
            "unit": "ns",
            "range": "± 8.74891851705304"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.NitoAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 784.8802742640178,
            "unit": "ns",
            "range": "± 6.97881372826288"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskContSyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 947.3162132263184,
            "unit": "ns",
            "range": "± 8.37070345617884"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 3965.1331020355224,
            "unit": "ns",
            "range": "± 138.01518131714622"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.ProtoPromiseAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 878.3147596995036,
            "unit": "ns",
            "range": "± 13.836530135593625"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 994.1874992052714,
            "unit": "ns",
            "range": "± 2.8629764622884175"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 1002.92001953125,
            "unit": "ns",
            "range": "± 1.6106409713751775"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 1008.1387378374735,
            "unit": "ns",
            "range": "± 1.046733577994651"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 1026.1616141979512,
            "unit": "ns",
            "range": "± 28.12875010011131"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskContSyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 1381.4608011979324,
            "unit": "ns",
            "range": "± 3.3815975777862315"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.NitoAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 4119.055351257324,
            "unit": "ns",
            "range": "± 54.15723588947454"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 4840.918875630697,
            "unit": "ns",
            "range": "± 89.9466741256519"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.ProtoPromiseAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 4661.387957436697,
            "unit": "ns",
            "range": "± 45.35617236758476"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 6037.011905415853,
            "unit": "ns",
            "range": "± 94.17451791106774"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 6359.200819905599,
            "unit": "ns",
            "range": "± 117.4962309855357"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.RefImplAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 6733.748538208008,
            "unit": "ns",
            "range": "± 91.38286578908829"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 6830.990430196126,
            "unit": "ns",
            "range": "± 103.86204734278988"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 6977.39933189979,
            "unit": "ns",
            "range": "± 49.86045571823094"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.NitoAsyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 7795.046763102214,
            "unit": "ns",
            "range": "± 67.07693666095962"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskContSyncAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 9556.709166463215,
            "unit": "ns",
            "range": "± 92.22046016864053"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskAutoResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 26222.19771684919,
            "unit": "ns",
            "range": "± 435.5829087620326"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.ProtoPromiseAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 8694.735730489096,
            "unit": "ns",
            "range": "± 52.52714670206118"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 10202.053371722881,
            "unit": "ns",
            "range": "± 13.7280327275584"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 10214.312069163603,
            "unit": "ns",
            "range": "± 204.64832962800574"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 10305.000282874475,
            "unit": "ns",
            "range": "± 46.90341912392406"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 10321.307131086078,
            "unit": "ns",
            "range": "± 61.00858196644138"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskContSyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 13651.26658450856,
            "unit": "ns",
            "range": "± 277.67476797040325"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.NitoAsyncAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 32886.10084751674,
            "unit": "ns",
            "range": "± 189.65271494064527"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncAutoResetEventWaitThenSetBenchmark.PooledAsTaskAutoResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 33346.002014160156,
            "unit": "ns",
            "range": "± 475.37110121739806"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncBarrierSignalAndWaitBenchmark.SignalAndWaitPooledAsync(ParticipantCount: 1)",
            "value": 26.94544546519007,
            "unit": "ns",
            "range": "± 0.3175913843851435"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncBarrierSignalAndWaitBenchmark.SignalAndWaitBarrierStandard(ParticipantCount: 1)",
            "value": 927.6722682952881,
            "unit": "ns",
            "range": "± 14.406266272362917"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncBarrierSignalAndWaitBenchmark.SignalAndWaitRefImplAsync(ParticipantCount: 1)",
            "value": 2228.4717178344727,
            "unit": "ns",
            "range": "± 31.163376434787533"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncBarrierSignalAndWaitBenchmark.SignalAndWaitPooledAsync(ParticipantCount: 10)",
            "value": 477.86143787090595,
            "unit": "ns",
            "range": "± 1.1175301224883596"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncBarrierSignalAndWaitBenchmark.SignalAndWaitRefImplAsync(ParticipantCount: 10)",
            "value": 3835.331979751587,
            "unit": "ns",
            "range": "± 84.93730739430123"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncBarrierSignalAndWaitBenchmark.SignalAndWaitBarrierStandard(ParticipantCount: 10)",
            "value": 29465.98611237282,
            "unit": "ns",
            "range": "± 1801.7434968143696"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.SignalAndWaitCountdownEventStandard(ParticipantCount: 1)",
            "value": 12.770665851022516,
            "unit": "ns",
            "range": "± 0.029995028352291658"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.SignalAndWaitProtoPromisesAsync(ParticipantCount: 1)",
            "value": 14.915425394590084,
            "unit": "ns",
            "range": "± 0.012544562896089488"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.SignalAndWaitPooledAsync(ParticipantCount: 1)",
            "value": 16.849535687764487,
            "unit": "ns",
            "range": "± 0.021665249584445854"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.SignalAndWaitRefImplAsync(ParticipantCount: 1)",
            "value": 34.688111579418184,
            "unit": "ns",
            "range": "± 0.27266682645393187"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.WaitAndSignalProtoPromisesAsync(ParticipantCount: 1)",
            "value": 37.084638341267905,
            "unit": "ns",
            "range": "± 0.05868546392136079"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.WaitAndSignalPooledAsync(ParticipantCount: 1)",
            "value": 92.72012434686933,
            "unit": "ns",
            "range": "± 0.766859227594673"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.SignalAndWaitProtoPromisesAsync(ParticipantCount: 10)",
            "value": 31.335550661270435,
            "unit": "ns",
            "range": "± 0.13877455676155445"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.SignalAndWaitCountdownEventStandard(ParticipantCount: 10)",
            "value": 37.46065396467845,
            "unit": "ns",
            "range": "± 0.08148826865136055"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.SignalAndWaitPooledAsync(ParticipantCount: 10)",
            "value": 44.176643422671724,
            "unit": "ns",
            "range": "± 0.13529971635689"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.WaitAndSignalProtoPromisesAsync(ParticipantCount: 10)",
            "value": 54.25285643797655,
            "unit": "ns",
            "range": "± 0.04629624505486114"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.SignalAndWaitRefImplAsync(ParticipantCount: 10)",
            "value": 58.853855498631795,
            "unit": "ns",
            "range": "± 0.3369778130233667"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncCountdownEventSignalBenchmark.WaitAndSignalPooledAsync(ParticipantCount: 10)",
            "value": 115.3190404681059,
            "unit": "ns",
            "range": "± 0.2827760447312231"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledMultipleAsync(cancellationType: None, Iterations: 0)",
            "value": 18.401391249895095,
            "unit": "ns",
            "range": "± 0.03791964592687477"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledTaskMultipleAsync(cancellationType: None, Iterations: 0)",
            "value": 22.235946063811962,
            "unit": "ns",
            "range": "± 0.03428158904167058"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockProtoPromiseMultipleAsync(cancellationType: None, Iterations: 0)",
            "value": 31.485998217548644,
            "unit": "ns",
            "range": "± 0.04056602256366802"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockVSThreadingMultipleAsync(cancellationType: None, Iterations: 0)",
            "value": 33.448690354824066,
            "unit": "ns",
            "range": "± 0.044827951603490464"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockSemaphoreSlimMultipleAsync(cancellationType: None, Iterations: 0)",
            "value": 36.06105800611632,
            "unit": "ns",
            "range": "± 0.05670424339351946"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockRefImplMultipleAsync(cancellationType: None, Iterations: 0)",
            "value": 39.81785783597401,
            "unit": "ns",
            "range": "± 0.04713868474509837"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNonKeyedMultipleAsync(cancellationType: None, Iterations: 0)",
            "value": 48.405012152024675,
            "unit": "ns",
            "range": "± 0.06227453834437391"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNitoMultipleAsync(cancellationType: None, Iterations: 0)",
            "value": 104.33306281963984,
            "unit": "ns",
            "range": "± 1.1458819329798784"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNeoSmartMultipleAsync(cancellationType: None, Iterations: 0)",
            "value": 130.1640929698944,
            "unit": "ns",
            "range": "± 0.6515946609288744"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledMultipleAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 19.408391459630085,
            "unit": "ns",
            "range": "± 0.08038383519610975"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledTaskMultipleAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 22.40549944128309,
            "unit": "ns",
            "range": "± 0.03406846053773213"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockProtoPromiseMultipleAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 22.86780690933977,
            "unit": "ns",
            "range": "± 0.03707791869153518"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockVSThreadingMultipleAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 34.626065492630005,
            "unit": "ns",
            "range": "± 0.03206961533221026"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockSemaphoreSlimMultipleAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 40.824945458344054,
            "unit": "ns",
            "range": "± 0.12656590150455074"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNonKeyedMultipleAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 51.86541976034641,
            "unit": "ns",
            "range": "± 0.05401017552941064"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNitoMultipleAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 111.62356321016948,
            "unit": "ns",
            "range": "± 1.3491339292593663"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNeoSmartMultipleAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 136.89445182482402,
            "unit": "ns",
            "range": "± 0.5635877940720844"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledMultipleAsync(cancellationType: None, Iterations: 1)",
            "value": 57.23114844468924,
            "unit": "ns",
            "range": "± 0.13256676604324252"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockProtoPromiseMultipleAsync(cancellationType: None, Iterations: 1)",
            "value": 73.26863128798348,
            "unit": "ns",
            "range": "± 0.41402871057323065"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockSemaphoreSlimMultipleAsync(cancellationType: None, Iterations: 1)",
            "value": 101.91771702124522,
            "unit": "ns",
            "range": "± 0.23074102826841728"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockVSThreadingMultipleAsync(cancellationType: None, Iterations: 1)",
            "value": 151.2253861597606,
            "unit": "ns",
            "range": "± 0.6532348497234004"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockRefImplMultipleAsync(cancellationType: None, Iterations: 1)",
            "value": 173.50894201718845,
            "unit": "ns",
            "range": "± 0.796922362659171"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNitoMultipleAsync(cancellationType: None, Iterations: 1)",
            "value": 247.96897722880047,
            "unit": "ns",
            "range": "± 2.9912657340218707"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNeoSmartMultipleAsync(cancellationType: None, Iterations: 1)",
            "value": 273.65828138987223,
            "unit": "ns",
            "range": "± 2.537393628995125"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledTaskMultipleAsync(cancellationType: None, Iterations: 1)",
            "value": 1045.4086012159075,
            "unit": "ns",
            "range": "± 35.63016574429593"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNonKeyedMultipleAsync(cancellationType: None, Iterations: 1)",
            "value": 1230.0746178944905,
            "unit": "ns",
            "range": "± 8.633984844577684"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledMultipleAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 90.21636848790305,
            "unit": "ns",
            "range": "± 0.22919436740491467"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockProtoPromiseMultipleAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 116.94362465540569,
            "unit": "ns",
            "range": "± 0.17190791823591528"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockVSThreadingMultipleAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 176.72406988877518,
            "unit": "ns",
            "range": "± 0.8157923785932176"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNeoSmartMultipleAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 272.6975245108971,
            "unit": "ns",
            "range": "± 2.707158377835353"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNitoMultipleAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 789.9885418574015,
            "unit": "ns",
            "range": "± 12.577500643084223"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledTaskMultipleAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 1115.465554300944,
            "unit": "ns",
            "range": "± 7.165928416734048"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockSemaphoreSlimMultipleAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 1281.4153954823812,
            "unit": "ns",
            "range": "± 5.828872838402987"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNonKeyedMultipleAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 1474.5987962086995,
            "unit": "ns",
            "range": "± 7.952706966477713"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockProtoPromiseMultipleAsync(cancellationType: None, Iterations: 10)",
            "value": 513.1865499360221,
            "unit": "ns",
            "range": "± 7.944653431336916"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledMultipleAsync(cancellationType: None, Iterations: 10)",
            "value": 592.1733659335545,
            "unit": "ns",
            "range": "± 1.8910134817987734"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockSemaphoreSlimMultipleAsync(cancellationType: None, Iterations: 10)",
            "value": 626.2703510011945,
            "unit": "ns",
            "range": "± 6.376431129263823"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockVSThreadingMultipleAsync(cancellationType: None, Iterations: 10)",
            "value": 1266.998082224528,
            "unit": "ns",
            "range": "± 13.790143497162482"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockRefImplMultipleAsync(cancellationType: None, Iterations: 10)",
            "value": 1436.1548531850178,
            "unit": "ns",
            "range": "± 5.7975476768779535"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNitoMultipleAsync(cancellationType: None, Iterations: 10)",
            "value": 1511.0937433242798,
            "unit": "ns",
            "range": "± 28.915806611030963"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNeoSmartMultipleAsync(cancellationType: None, Iterations: 10)",
            "value": 1520.4710112980433,
            "unit": "ns",
            "range": "± 10.564305417176385"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledTaskMultipleAsync(cancellationType: None, Iterations: 10)",
            "value": 5556.513635253907,
            "unit": "ns",
            "range": "± 148.4169771514943"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNonKeyedMultipleAsync(cancellationType: None, Iterations: 10)",
            "value": 6487.185270547867,
            "unit": "ns",
            "range": "± 197.19446898972296"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockProtoPromiseMultipleAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 931.3570240656535,
            "unit": "ns",
            "range": "± 15.575251094173879"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledMultipleAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 987.9434913907733,
            "unit": "ns",
            "range": "± 1.323523249398031"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNeoSmartMultipleAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 1513.6034336090088,
            "unit": "ns",
            "range": "± 17.10270616160536"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockVSThreadingMultipleAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 1621.8411641438802,
            "unit": "ns",
            "range": "± 17.302823412076567"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNitoMultipleAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 5278.405865478516,
            "unit": "ns",
            "range": "± 84.23315796642689"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledTaskMultipleAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 6517.826112227006,
            "unit": "ns",
            "range": "± 228.8043279488341"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockSemaphoreSlimMultipleAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 9418.326080322266,
            "unit": "ns",
            "range": "± 379.367859935314"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNonKeyedMultipleAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 11704.526010660025,
            "unit": "ns",
            "range": "± 482.75108351579513"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockProtoPromiseMultipleAsync(cancellationType: None, Iterations: 100)",
            "value": 5041.9997249603275,
            "unit": "ns",
            "range": "± 114.34684434920763"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledMultipleAsync(cancellationType: None, Iterations: 100)",
            "value": 5740.859294128418,
            "unit": "ns",
            "range": "± 15.615947527603852"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockSemaphoreSlimMultipleAsync(cancellationType: None, Iterations: 100)",
            "value": 6071.107890319824,
            "unit": "ns",
            "range": "± 40.81989010816075"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockVSThreadingMultipleAsync(cancellationType: None, Iterations: 100)",
            "value": 11917.003282674154,
            "unit": "ns",
            "range": "± 71.48908157314646"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNeoSmartMultipleAsync(cancellationType: None, Iterations: 100)",
            "value": 13550.413677978515,
            "unit": "ns",
            "range": "± 141.60462138883187"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNitoMultipleAsync(cancellationType: None, Iterations: 100)",
            "value": 14155.880369013006,
            "unit": "ns",
            "range": "± 343.60853111476837"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockRefImplMultipleAsync(cancellationType: None, Iterations: 100)",
            "value": 14514.921100071499,
            "unit": "ns",
            "range": "± 143.29591899368708"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledTaskMultipleAsync(cancellationType: None, Iterations: 100)",
            "value": 46273.59812825521,
            "unit": "ns",
            "range": "± 1358.6783284369722"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNonKeyedMultipleAsync(cancellationType: None, Iterations: 100)",
            "value": 54293.51700846354,
            "unit": "ns",
            "range": "± 1801.0154408535786"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockProtoPromiseMultipleAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 9211.240861075265,
            "unit": "ns",
            "range": "± 45.188358665606906"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledMultipleAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 10361.054178091195,
            "unit": "ns",
            "range": "± 17.519169282490335"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNeoSmartMultipleAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 13636.440737043109,
            "unit": "ns",
            "range": "± 204.72690941275206"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockVSThreadingMultipleAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 15623.649403163365,
            "unit": "ns",
            "range": "± 159.69584168965534"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNitoMultipleAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 44273.30739339193,
            "unit": "ns",
            "range": "± 733.9154370679636"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockPooledTaskMultipleAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 54367.79478759765,
            "unit": "ns",
            "range": "± 439.8773897701277"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockSemaphoreSlimMultipleAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 74260.98705115684,
            "unit": "ns",
            "range": "± 305.9275276206579"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark.LockUnlockNonKeyedMultipleAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 93215.70309244792,
            "unit": "ns",
            "range": "± 1366.3914871920829"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.IncrementSingle",
            "value": 0.0012567088540111268,
            "unit": "ns",
            "range": "± 0.0018402931520499263"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.InterlockedAdd",
            "value": 0.3671549864645515,
            "unit": "ns",
            "range": "± 0.003132475862094485"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.InterlockedIncrementSingle",
            "value": 0.3719752130027001,
            "unit": "ns",
            "range": "± 0.003548770344866635"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.InterlockedExchange",
            "value": 0.9644368523015425,
            "unit": "ns",
            "range": "± 0.0007532648493499182"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.InterlockedCompareExchange",
            "value": 1.6102069811179087,
            "unit": "ns",
            "range": "± 0.001406432641740703"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockUnlockCryptoHivesSpinLockSingleAsync",
            "value": 7.5203567904730635,
            "unit": "ns",
            "range": "± 0.013523191829326354"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockEnterScopeSingle",
            "value": 7.847671092620918,
            "unit": "ns",
            "range": "± 0.017698819107526652"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockUnlockSingle",
            "value": 8.025379026929537,
            "unit": "ns",
            "range": "± 0.06490858375475297"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.ObjectLockUnlockSingle",
            "value": 9.54737931809255,
            "unit": "ns",
            "range": "± 0.017685210603085873"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockUnlockPooledSingleAsync",
            "value": 14.928693062067032,
            "unit": "ns",
            "range": "± 0.03131103511743719"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockUnlockProtoPromiseSingleAsync",
            "value": 15.446183883718081,
            "unit": "ns",
            "range": "± 0.030086748191552666"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockUnlockVSThreadingSingleAsync",
            "value": 30.74698933462302,
            "unit": "ns",
            "range": "± 0.018013848346992867"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockUnlockSemaphoreSlimSingleAsync",
            "value": 36.785598095258074,
            "unit": "ns",
            "range": "± 0.12519263688568114"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockUnlockRefImplSingleAsync",
            "value": 41.11521592736244,
            "unit": "ns",
            "range": "± 0.07714188711684954"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.SpinWaitSingle",
            "value": 45.33237039125883,
            "unit": "ns",
            "range": "± 0.026188053009503835"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockUnlockNonKeyedSingleAsync",
            "value": 46.82672475851499,
            "unit": "ns",
            "range": "± 0.06319428913427264"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockUnlockSpinLockSingleAsync",
            "value": 59.40840203421457,
            "unit": "ns",
            "range": "± 0.08256044598150555"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockUnlockNitoSingleAsync",
            "value": 97.79179527078357,
            "unit": "ns",
            "range": "± 0.2222121663499992"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark.LockUnlockNeoSmartSingleAsync",
            "value": 128.52627825737,
            "unit": "ns",
            "range": "± 0.37386510885385293"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventSetResetBenchmark.ProtoPromiseAsyncManualResetEventSetReset",
            "value": 2.514754663620676,
            "unit": "ns",
            "range": "± 0.006316888719451235"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventSetResetBenchmark.PooledAsyncManualResetEventSetReset",
            "value": 3.7722369661288604,
            "unit": "ns",
            "range": "± 0.0036359847459960463"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventSetResetBenchmark.ManualResetEventSlimSetReset",
            "value": 10.922213720423835,
            "unit": "ns",
            "range": "± 0.024417679329130654"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventSetResetBenchmark.RefImplAsyncManualResetEventSetReset",
            "value": 24.625562539467445,
            "unit": "ns",
            "range": "± 0.17253631828384858"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventSetResetBenchmark.NitoAsyncManualResetEventSetReset",
            "value": 43.694900359710054,
            "unit": "ns",
            "range": "± 0.218648749018816"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventSetResetBenchmark.ManualResetEventSetReset",
            "value": 192.81367705418512,
            "unit": "ns",
            "range": "± 0.1704741599481147"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventSetThenWaitBenchmark.ProtoPromiseAsyncManualResetEventSetThenWaitAsync",
            "value": 11.783972225510157,
            "unit": "ns",
            "range": "± 0.022164113925052527"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventSetThenWaitBenchmark.PooledAsTaskAsyncManualResetEventSetThenWaitAsync",
            "value": 17.809958499211533,
            "unit": "ns",
            "range": "± 0.040481491961504946"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventSetThenWaitBenchmark.PooledAsyncManualResetEventSetThenWaitAsync",
            "value": 18.376801216602324,
            "unit": "ns",
            "range": "± 0.022043931048236928"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventSetThenWaitBenchmark.RefImplAsyncManualResetEventSetThenWaitAsync",
            "value": 32.39392347420965,
            "unit": "ns",
            "range": "± 0.31693164152520814"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventSetThenWaitBenchmark.NitoAsyncManualResetEventSetThenWaitAsync",
            "value": 61.57249325972337,
            "unit": "ns",
            "range": "± 0.2166432522102864"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 43.70817947884401,
            "unit": "ns",
            "range": "± 0.03546872794400285"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 44.180617676331444,
            "unit": "ns",
            "range": "± 0.07477748100461126"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.RefImplAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 44.63272924820582,
            "unit": "ns",
            "range": "± 0.31708208099388513"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 49.843082680152015,
            "unit": "ns",
            "range": "± 0.03160281007968806"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 49.899261172612505,
            "unit": "ns",
            "range": "± 0.17398421198970232"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.ProtoPromiseAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 52.937921868903295,
            "unit": "ns",
            "range": "± 0.1430799197175885"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.NitoAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 67.06355846779687,
            "unit": "ns",
            "range": "± 0.26882608997691637"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskContSyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 72.35804872787915,
            "unit": "ns",
            "range": "± 0.15233488976698117"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 1)",
            "value": 1020.9026067040184,
            "unit": "ns",
            "range": "± 37.606950023967805"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 73.54777136215797,
            "unit": "ns",
            "range": "± 0.298466141028901"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 75.22555439869562,
            "unit": "ns",
            "range": "± 0.9507100370899195"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 77.44793167710304,
            "unit": "ns",
            "range": "± 0.3088580801781226"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 78.6128987312317,
            "unit": "ns",
            "range": "± 0.1695380515314079"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.ProtoPromiseAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 89.02795507907868,
            "unit": "ns",
            "range": "± 0.20005166913439576"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskContSyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 113.11754030386606,
            "unit": "ns",
            "range": "± 0.39647987746410973"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 1064.2171459197998,
            "unit": "ns",
            "range": "± 19.861249382166246"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.NitoAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 1455.195948791504,
            "unit": "ns",
            "range": "± 6.300737606589237"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.RefImplAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 48.246613228321074,
            "unit": "ns",
            "range": "± 0.7031256209129764"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.NitoAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 85.70059620141983,
            "unit": "ns",
            "range": "± 0.49155177018909485"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.ProtoPromiseAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 88.02619431700025,
            "unit": "ns",
            "range": "± 0.2556788373903956"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 99.51250542913165,
            "unit": "ns",
            "range": "± 0.41537026200335936"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 100.63321254650752,
            "unit": "ns",
            "range": "± 0.5162717676709587"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 110.13782809461865,
            "unit": "ns",
            "range": "± 0.5666626659018789"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 110.42476320266724,
            "unit": "ns",
            "range": "± 0.43308591381534045"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskContSyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 165.17269560268946,
            "unit": "ns",
            "range": "± 0.6246259719401449"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 2)",
            "value": 1551.34453286065,
            "unit": "ns",
            "range": "± 31.829102737864527"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 169.73978460752048,
            "unit": "ns",
            "range": "± 0.37928582585253945"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 171.20232448211084,
            "unit": "ns",
            "range": "± 0.4863314889416502"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 174.87697360912958,
            "unit": "ns",
            "range": "± 0.5261125898520062"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.ProtoPromiseAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 175.00508389870325,
            "unit": "ns",
            "range": "± 0.9922719415854193"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 179.31835213074316,
            "unit": "ns",
            "range": "± 0.31118666766553504"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskContSyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 251.71405029296875,
            "unit": "ns",
            "range": "± 0.284041564581074"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 1695.1118871900771,
            "unit": "ns",
            "range": "± 34.040027918026475"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.NitoAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 2447.7587113013633,
            "unit": "ns",
            "range": "± 10.723252510664823"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.RefImplAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 116.74643771251043,
            "unit": "ns",
            "range": "± 0.7447627821299827"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.NitoAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 238.76689427693685,
            "unit": "ns",
            "range": "± 2.056149733435964"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.ProtoPromiseAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 427.8352463722229,
            "unit": "ns",
            "range": "± 1.9424155781101817"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 555.6215664790227,
            "unit": "ns",
            "range": "± 2.2837489467472274"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 563.2773443368765,
            "unit": "ns",
            "range": "± 1.3307308222818484"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 587.9996027579674,
            "unit": "ns",
            "range": "± 0.8839942890478938"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 635.6749960354397,
            "unit": "ns",
            "range": "± 1.634220694545267"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskContSyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 864.5419103758676,
            "unit": "ns",
            "range": "± 7.499573706341276"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 10)",
            "value": 3942.1813347048874,
            "unit": "ns",
            "range": "± 139.15460284386282"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.ProtoPromiseAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 843.6109741074698,
            "unit": "ns",
            "range": "± 3.7881702564712527"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 954.6285245077951,
            "unit": "ns",
            "range": "± 2.6157278773371524"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 958.3522367477417,
            "unit": "ns",
            "range": "± 1.9028365854908047"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 978.3037982214065,
            "unit": "ns",
            "range": "± 23.066350206704183"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 981.5489914417267,
            "unit": "ns",
            "range": "± 25.591160516788598"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskContSyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 1352.1143463134765,
            "unit": "ns",
            "range": "± 6.666258039757521"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 5013.311030273438,
            "unit": "ns",
            "range": "± 131.38796891507943"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.NitoAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 8468.879016081491,
            "unit": "ns",
            "range": "± 603.4932997000814"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.RefImplAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 982.1662979920706,
            "unit": "ns",
            "range": "± 10.293760187097687"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.NitoAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 2024.5974679834703,
            "unit": "ns",
            "range": "± 41.16049636789773"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.ProtoPromiseAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 4262.302709851946,
            "unit": "ns",
            "range": "± 66.5317349802083"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 5592.686411176409,
            "unit": "ns",
            "range": "± 87.74458067757566"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 5809.800057547433,
            "unit": "ns",
            "range": "± 53.763771275115026"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 6189.491766866048,
            "unit": "ns",
            "range": "± 57.734204526647005"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 6403.005940755208,
            "unit": "ns",
            "range": "± 97.27875678132425"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskContSyncManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 8853.202384361854,
            "unit": "ns",
            "range": "± 50.35930657573832"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskManualResetEventWaitThenSetAsync(cancellationType: None, Iterations: 100)",
            "value": 26160.548135375975,
            "unit": "ns",
            "range": "± 422.6875869028546"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.ProtoPromiseAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 8198.268362426757,
            "unit": "ns",
            "range": "± 72.58172248336473"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 9763.614332932691,
            "unit": "ns",
            "range": "± 63.34324468849762"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 9774.538642296424,
            "unit": "ns",
            "range": "± 70.17950020617714"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 9774.760861910307,
            "unit": "ns",
            "range": "± 58.41503833952271"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 9793.826165335518,
            "unit": "ns",
            "range": "± 17.845099517063947"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskContSyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 13317.276997492863,
            "unit": "ns",
            "range": "± 164.2644372143577"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.PooledAsTaskManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 33705.28628336589,
            "unit": "ns",
            "range": "± 603.37149303668"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncManualResetEventWaitThenSetBenchmark.NitoAsyncManualResetEventWaitThenSetAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 53919.56479492188,
            "unit": "ns",
            "range": "± 563.4818763312852"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 0)",
            "value": 16.89980451124055,
            "unit": "ns",
            "range": "± 0.01859266409856266"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockPooledAsync(cancellationType: None, Iterations: 0)",
            "value": 21.32461693485578,
            "unit": "ns",
            "range": "± 0.023405704623756476"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockProtoPromisesAsync(cancellationType: None, Iterations: 0)",
            "value": 35.0309618751208,
            "unit": "ns",
            "range": "± 0.05800452786317793"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockRefImplAsync(cancellationType: None, Iterations: 0)",
            "value": 42.405838642801555,
            "unit": "ns",
            "range": "± 0.15614988931978796"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockNitoAsync(cancellationType: None, Iterations: 0)",
            "value": 101.82195236001697,
            "unit": "ns",
            "range": "± 0.24054863434162113"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 0)",
            "value": 452.7959713569054,
            "unit": "ns",
            "range": "± 1.456797339551641"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockPooledAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 23.29874821503957,
            "unit": "ns",
            "range": "± 0.03255522555025804"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 35.07673966033118,
            "unit": "ns",
            "range": "± 0.0276256412871522"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockNitoAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 102.35997219880421,
            "unit": "ns",
            "range": "± 1.514544225163552"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 453.2331100977384,
            "unit": "ns",
            "range": "± 3.1941391642451364"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 1)",
            "value": 30.505397119692393,
            "unit": "ns",
            "range": "± 0.03695656013037303"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockPooledAsync(cancellationType: None, Iterations: 1)",
            "value": 39.307631850242615,
            "unit": "ns",
            "range": "± 0.030080673904963526"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockProtoPromisesAsync(cancellationType: None, Iterations: 1)",
            "value": 54.35000700610025,
            "unit": "ns",
            "range": "± 0.04362871859422684"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockRefImplAsync(cancellationType: None, Iterations: 1)",
            "value": 65.80175964037578,
            "unit": "ns",
            "range": "± 0.18931422211650678"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockNitoAsync(cancellationType: None, Iterations: 1)",
            "value": 205.51312341008867,
            "unit": "ns",
            "range": "± 1.156464394717871"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 1)",
            "value": 1095.2188889639717,
            "unit": "ns",
            "range": "± 4.337630797584673"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockPooledAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 37.95841845018523,
            "unit": "ns",
            "range": "± 0.021929571523526502"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 55.498903304338455,
            "unit": "ns",
            "range": "± 0.06261451626140556"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockNitoAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 207.0393431186676,
            "unit": "ns",
            "range": "± 2.448059476630725"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 1171.3510902111348,
            "unit": "ns",
            "range": "± 6.486092852543694"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 10)",
            "value": 169.32875059445698,
            "unit": "ns",
            "range": "± 0.15605621117276552"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockPooledAsync(cancellationType: None, Iterations: 10)",
            "value": 203.3250896135966,
            "unit": "ns",
            "range": "± 0.15498027715203555"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockProtoPromisesAsync(cancellationType: None, Iterations: 10)",
            "value": 266.94570875167847,
            "unit": "ns",
            "range": "± 0.14879174035197537"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockRefImplAsync(cancellationType: None, Iterations: 10)",
            "value": 312.0511172498976,
            "unit": "ns",
            "range": "± 0.5122600425623111"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockNitoAsync(cancellationType: None, Iterations: 10)",
            "value": 1150.7655169169109,
            "unit": "ns",
            "range": "± 21.119600248759514"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 10)",
            "value": 7193.486126200358,
            "unit": "ns",
            "range": "± 18.422825414449363"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockPooledAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 202.36356869110693,
            "unit": "ns",
            "range": "± 0.27929952022689897"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 273.66336706706454,
            "unit": "ns",
            "range": "± 0.0779259646451685"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockNitoAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 1149.4282221476237,
            "unit": "ns",
            "range": "± 14.963514899369432"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 10)",
            "value": 7180.306082661947,
            "unit": "ns",
            "range": "± 62.5700060625228"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 100)",
            "value": 1531.3827322642007,
            "unit": "ns",
            "range": "± 1.4026506403648613"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockPooledAsync(cancellationType: None, Iterations: 100)",
            "value": 1912.0711698532104,
            "unit": "ns",
            "range": "± 1.514429400132876"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockProtoPromisesAsync(cancellationType: None, Iterations: 100)",
            "value": 2329.8705884297688,
            "unit": "ns",
            "range": "± 2.5119028916526656"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockRefImplAsync(cancellationType: None, Iterations: 100)",
            "value": 2878.8786137898765,
            "unit": "ns",
            "range": "± 3.3258473727586244"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockNitoAsync(cancellationType: None, Iterations: 100)",
            "value": 10616.129889351982,
            "unit": "ns",
            "range": "± 162.6989007944536"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 100)",
            "value": 169200.92832728795,
            "unit": "ns",
            "range": "± 806.306949522257"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockPooledAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 1925.3760683695475,
            "unit": "ns",
            "range": "± 2.408215715893867"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 2390.0561411721364,
            "unit": "ns",
            "range": "± 2.04371838405584"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockNitoAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 10492.912475585938,
            "unit": "ns",
            "range": "± 88.92266259399001"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 100)",
            "value": 167574.67292131696,
            "unit": "ns",
            "range": "± 513.01378716563"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 0)",
            "value": 16.34301461492266,
            "unit": "ns",
            "range": "± 0.01918503441630081"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockPooledAsync(cancellationType: None, Iterations: 0)",
            "value": 24.407969530423482,
            "unit": "ns",
            "range": "± 0.03514077188225375"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockProtoPromisesAsync(cancellationType: None, Iterations: 0)",
            "value": 31.846943416765757,
            "unit": "ns",
            "range": "± 0.06315768651412262"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 0)",
            "value": 2596.7039495195663,
            "unit": "ns",
            "range": "± 17.513504367572796"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockPooledAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 23.57178412950956,
            "unit": "ns",
            "range": "± 0.02195852607332787"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 32.52683244006975,
            "unit": "ns",
            "range": "± 0.03049572120294292"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 2595.2261255900066,
            "unit": "ns",
            "range": "± 19.247795492583446"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 1)",
            "value": 16.014767849019595,
            "unit": "ns",
            "range": "± 0.017585823622156684"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockPooledAsync(cancellationType: None, Iterations: 1)",
            "value": 27.204524989311512,
            "unit": "ns",
            "range": "± 0.024462463210764757"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockProtoPromisesAsync(cancellationType: None, Iterations: 1)",
            "value": 30.78515481031858,
            "unit": "ns",
            "range": "± 0.14416064266916478"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 1)",
            "value": 2509.623374938965,
            "unit": "ns",
            "range": "± 9.404232922711797"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 31.121928619486944,
            "unit": "ns",
            "range": "± 0.11629248206191083"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockPooledAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 34.11667481752542,
            "unit": "ns",
            "range": "± 0.02004918924292897"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 2672.7890526907786,
            "unit": "ns",
            "range": "± 14.204824975414686"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 2)",
            "value": 16.80706027150154,
            "unit": "ns",
            "range": "± 0.02536318685209248"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockPooledAsync(cancellationType: None, Iterations: 2)",
            "value": 27.054778795975906,
            "unit": "ns",
            "range": "± 0.03207009004555983"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockProtoPromisesAsync(cancellationType: None, Iterations: 2)",
            "value": 31.272513846556347,
            "unit": "ns",
            "range": "± 0.08970218432063426"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 2)",
            "value": 2582.4695592244466,
            "unit": "ns",
            "range": "± 16.205372808458467"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockPooledAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 27.057607173919678,
            "unit": "ns",
            "range": "± 0.015540015122289225"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 30.541772472006933,
            "unit": "ns",
            "range": "± 0.18048473387625577"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 2660.174651806171,
            "unit": "ns",
            "range": "± 9.864460753701147"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 5)",
            "value": 64.05247016463962,
            "unit": "ns",
            "range": "± 0.06299707162706715"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockPooledAsync(cancellationType: None, Iterations: 5)",
            "value": 88.24667102556963,
            "unit": "ns",
            "range": "± 0.16825573237169436"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockProtoPromisesAsync(cancellationType: None, Iterations: 5)",
            "value": 93.6537452169827,
            "unit": "ns",
            "range": "± 0.03362419457798752"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 5)",
            "value": 6398.705682825159,
            "unit": "ns",
            "range": "± 174.91656163398858"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockPooledAsync(cancellationType: NotCancelled, Iterations: 5)",
            "value": 86.48984642539706,
            "unit": "ns",
            "range": "± 0.10167038006862743"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.UpgradeableReaderLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 5)",
            "value": 96.09913975917377,
            "unit": "ns",
            "range": "± 0.063570711279732"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradeableReaderBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 5)",
            "value": 6572.242582841353,
            "unit": "ns",
            "range": "± 205.71956748019014"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 0)",
            "value": 33.46920177766255,
            "unit": "ns",
            "range": "± 0.055035100384012034"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockPooledAsync(cancellationType: None, Iterations: 0)",
            "value": 35.28128591179848,
            "unit": "ns",
            "range": "± 0.020002646120525318"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockProtoPromisesAsync(cancellationType: None, Iterations: 0)",
            "value": 39.14518061509499,
            "unit": "ns",
            "range": "± 0.04886347533858742"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 0)",
            "value": 4662.899597167969,
            "unit": "ns",
            "range": "± 68.38315613989916"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockPooledAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 33.765396907925606,
            "unit": "ns",
            "range": "± 0.03930798110911867"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 41.98000689424001,
            "unit": "ns",
            "range": "± 0.02219591524759803"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 0)",
            "value": 4680.540916866727,
            "unit": "ns",
            "range": "± 99.41661451178464"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 1)",
            "value": 50.59131728609403,
            "unit": "ns",
            "range": "± 0.14533073062450078"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockPooledAsync(cancellationType: None, Iterations: 1)",
            "value": 74.37328716883293,
            "unit": "ns",
            "range": "± 0.16474100103060246"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockProtoPromisesAsync(cancellationType: None, Iterations: 1)",
            "value": 97.08974939584732,
            "unit": "ns",
            "range": "± 0.034757464771815856"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 1)",
            "value": 5800.3655476888025,
            "unit": "ns",
            "range": "± 87.96343726075858"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockPooledAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 98.13668415943782,
            "unit": "ns",
            "range": "± 0.0661476527565077"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 131.73990518706185,
            "unit": "ns",
            "range": "± 0.10286317755002149"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 1)",
            "value": 5818.804682595389,
            "unit": "ns",
            "range": "± 32.653776121623544"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 2)",
            "value": 61.56754203637441,
            "unit": "ns",
            "range": "± 0.1077157616274419"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockPooledAsync(cancellationType: None, Iterations: 2)",
            "value": 93.52684488466808,
            "unit": "ns",
            "range": "± 0.09009495888742339"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockProtoPromisesAsync(cancellationType: None, Iterations: 2)",
            "value": 115.44363528490067,
            "unit": "ns",
            "range": "± 0.24837041662256829"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 2)",
            "value": 6771.146991984049,
            "unit": "ns",
            "range": "± 93.35959118758504"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockPooledAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 121.22972461155483,
            "unit": "ns",
            "range": "± 0.25450074344456863"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 150.88517288061288,
            "unit": "ns",
            "range": "± 0.4369526274403127"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 2)",
            "value": 6978.457635498047,
            "unit": "ns",
            "range": "± 85.75084027953201"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReadLockReaderWriterLockSlim(cancellationType: None, Iterations: 5)",
            "value": 105.78737700836999,
            "unit": "ns",
            "range": "± 0.11172331299426622"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockPooledAsync(cancellationType: None, Iterations: 5)",
            "value": 166.18123863424574,
            "unit": "ns",
            "range": "± 0.12511373905285028"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockProtoPromisesAsync(cancellationType: None, Iterations: 5)",
            "value": 179.79947088314935,
            "unit": "ns",
            "range": "± 0.21825453221719376"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReaderLockVSThreadingAsync(cancellationType: None, Iterations: 5)",
            "value": 10292.092252458844,
            "unit": "ns",
            "range": "± 143.64062392471055"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockPooledAsync(cancellationType: NotCancelled, Iterations: 5)",
            "value": 189.86419355869293,
            "unit": "ns",
            "range": "± 0.2289693420417421"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.UpgradedWriterLockProtoPromisesAsync(cancellationType: NotCancelled, Iterations: 5)",
            "value": 220.2105634609858,
            "unit": "ns",
            "range": "± 0.2445830651861924"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockUpgradedWriterBenchmark.ReaderLockVSThreadingAsync(cancellationType: NotCancelled, Iterations: 5)",
            "value": 10054.668810017904,
            "unit": "ns",
            "range": "± 96.75099436601643"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockWriterBenchmark.WriteLockReaderWriterLockSlim",
            "value": 15.450675439834594,
            "unit": "ns",
            "range": "± 0.02644082686205548"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockWriterBenchmark.WriterLockPooledAsync",
            "value": 17.677192583680153,
            "unit": "ns",
            "range": "± 0.015382545199800472"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockWriterBenchmark.WriterLockProtoPromisesAsync",
            "value": 18.9393202016751,
            "unit": "ns",
            "range": "± 0.01571712422613606"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockWriterBenchmark.WriterLockRefImplAsync",
            "value": 35.183241077831816,
            "unit": "ns",
            "range": "± 0.033695074830587576"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockWriterBenchmark.WriterLockNitoAsync",
            "value": 141.41806166512626,
            "unit": "ns",
            "range": "± 0.7072885307185652"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncReaderWriterLockWriterBenchmark.WriterLockVSThreadingAsync",
            "value": 2355.8444287618,
            "unit": "ns",
            "range": "± 12.573998433616541"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncSemaphoreSingleBenchmark.WaitReleaseProtoPromiseSingleAsync",
            "value": 12.44386525824666,
            "unit": "ns",
            "range": "± 0.004174048072919949"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncSemaphoreSingleBenchmark.WaitReleasePooledSingleAsync",
            "value": 17.925706901152928,
            "unit": "ns",
            "range": "± 0.021989521268397264"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncSemaphoreSingleBenchmark.WaitReleaseNitoSingleAsync",
            "value": 32.781300856516914,
            "unit": "ns",
            "range": "± 0.08930404429898578"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncSemaphoreSingleBenchmark.WaitReleaseRefImplSingleAsync",
            "value": 36.20959178606669,
            "unit": "ns",
            "range": "± 0.0372342413967104"
          },
          {
            "name": "Threading.Tests.Async.Pooled.AsyncSemaphoreSingleBenchmark.WaitReleaseSemaphoreSlimSingleAsync",
            "value": 37.10277167650369,
            "unit": "ns",
            "range": "± 0.05304278464800549"
          }
        ]
      }
    ]
  }
}