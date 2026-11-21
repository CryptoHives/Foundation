| Description                               | Iterations | cancellationType | Mean          | Error       | StdDev      | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------------:|------------:|------:|----------:|
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |      5.641 ns |   0.0247 ns |   0.0231 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      6.158 ns |   0.0539 ns |   0.0477 ns |  1.09 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |      7.738 ns |   0.0229 ns |   0.0214 ns |  1.37 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | None             |     12.304 ns |   0.0335 ns |   0.0313 ns |  2.18 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     13.870 ns |   0.0410 ns |   0.0383 ns |  2.46 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     43.874 ns |   0.1146 ns |   0.1072 ns |  7.78 |     312 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    216.780 ns |   0.9998 ns |   0.9353 ns | 38.43 |     208 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |      5.630 ns |   0.0155 ns |   0.0145 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |      7.399 ns |   0.0246 ns |   0.0218 ns |  1.31 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | NotCancelled     |     12.269 ns |   0.0290 ns |   0.0257 ns |  2.18 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     44.407 ns |   0.1613 ns |   0.1509 ns |  7.89 |     312 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    216.712 ns |   0.8173 ns |   0.7645 ns | 38.49 |     208 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     10.780 ns |   0.0404 ns |   0.0378 ns |  0.26 |         - | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     11.059 ns |   0.0436 ns |   0.0408 ns |  0.27 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | None             |     24.280 ns |   0.0635 ns |   0.0594 ns |  0.59 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     24.944 ns |   0.0680 ns |   0.0636 ns |  0.60 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     41.457 ns |   0.1812 ns |   0.1695 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     89.554 ns |   0.2428 ns |   0.2271 ns |  2.16 |     624 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    494.278 ns |   1.4807 ns |   1.3851 ns | 11.92 |     416 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     10.911 ns |   0.0390 ns |   0.0346 ns |  0.26 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | NotCancelled     |     24.021 ns |   0.0613 ns |   0.0573 ns |  0.58 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     41.635 ns |   0.1552 ns |   0.1452 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     89.801 ns |   0.2841 ns |   0.2657 ns |  2.16 |     624 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    495.152 ns |   1.6268 ns |   1.5217 ns | 11.89 |     416 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |     36.054 ns |   0.0899 ns |   0.0841 ns |  0.10 |         - | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     50.775 ns |   0.1237 ns |   0.1157 ns |  0.15 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | None             |    118.238 ns |   0.2607 ns |   0.2438 ns |  0.34 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    127.741 ns |   0.3568 ns |   0.3338 ns |  0.37 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    346.980 ns |   2.0839 ns |   1.9493 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    491.192 ns |   1.8587 ns |   1.7387 ns |  1.42 |    3432 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,444.080 ns |  10.5560 ns |   9.8741 ns |  9.93 |    2288 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |     39.001 ns |   0.1356 ns |   0.1268 ns |  0.12 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | NotCancelled     |    120.699 ns |   0.4507 ns |   0.4216 ns |  0.37 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    330.432 ns |   2.0309 ns |   1.8997 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    491.159 ns |   1.2981 ns |   1.2142 ns |  1.49 |    3432 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  3,463.617 ns |  11.2114 ns |  10.4872 ns | 10.48 |    2288 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |    313.964 ns |   0.9797 ns |   0.9164 ns |  0.09 |         - | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |    463.315 ns |   1.3187 ns |   1.2335 ns |  0.13 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | None             |  1,070.451 ns |   2.7542 ns |   2.4415 ns |  0.30 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,125.120 ns |   2.7786 ns |   2.5991 ns |  0.32 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  3,553.397 ns |  15.0308 ns |  14.0598 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,517.120 ns |  14.5562 ns |  13.6159 ns |  1.27 |   31512 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 79,581.992 ns | 264.8428 ns | 247.7341 ns | 22.40 |   21008 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |    349.431 ns |   1.3801 ns |   1.2910 ns |  0.10 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | NotCancelled     |  1,094.796 ns |   4.3465 ns |   4.0657 ns |  0.31 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  3,534.593 ns |   6.5339 ns |   6.1118 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,527.465 ns |  39.9656 ns |  37.3838 ns |  1.28 |   31512 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 78,113.337 ns | 128.5738 ns | 120.2680 ns | 22.10 |   21008 B |