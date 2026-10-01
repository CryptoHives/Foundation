| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     875.2 ns |     6.90 ns |     6.46 ns |     876.4 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |     987.7 ns |     5.11 ns |     4.27 ns |     986.8 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1,080.2 ns |     1.47 ns |     1.37 ns |   1,080.0 ns |     368 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     874.9 ns |     8.09 ns |     7.56 ns |     876.0 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |     989.9 ns |     5.35 ns |     4.75 ns |     990.1 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1,058.6 ns |     0.57 ns |     0.53 ns |   1,058.9 ns |     384 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,558.6 ns |     0.76 ns |     0.67 ns |   1,558.6 ns |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,341.8 ns |    11.30 ns |    10.57 ns |   2,341.7 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,768.9 ns |    53.46 ns |    69.52 ns |   2,796.4 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,560.9 ns |     0.83 ns |     0.74 ns |   1,561.0 ns |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,349.4 ns |    11.34 ns |    10.05 ns |   2,344.6 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,778.2 ns |    55.36 ns |    71.98 ns |   2,805.4 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |   5,437.2 ns |     3.28 ns |     2.91 ns |   5,437.8 ns |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  13,199.5 ns |    37.05 ns |    30.94 ns |  13,196.5 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  17,939.0 ns |   351.06 ns |   546.56 ns |  18,104.9 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        |  77,435.4 ns |    87.15 ns |    68.04 ns |  77,441.5 ns |  131340 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 198,833.7 ns | 1,000.72 ns |   887.11 ns | 198,699.5 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 280,089.0 ns | 5,531.65 ns | 7,571.78 ns | 284,291.7 ns |         - |