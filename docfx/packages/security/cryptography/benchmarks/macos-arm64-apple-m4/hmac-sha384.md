| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     866.1 ns |     4.76 ns |     4.45 ns |     865.8 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,014.4 ns |     3.18 ns |     2.98 ns |   1,015.2 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1,137.9 ns |     4.53 ns |     4.23 ns |   1,138.8 ns |     368 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     871.3 ns |     2.97 ns |     2.77 ns |     871.1 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,017.9 ns |     2.68 ns |     2.37 ns |   1,018.4 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1,110.4 ns |     6.38 ns |     5.96 ns |   1,109.4 ns |     384 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,694.2 ns |     6.94 ns |     6.50 ns |   1,694.0 ns |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,404.7 ns |     7.82 ns |     7.31 ns |   2,406.9 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,778.5 ns |    14.31 ns |    13.38 ns |   2,783.8 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,606.5 ns |     5.68 ns |     5.32 ns |   1,606.8 ns |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,406.8 ns |     8.97 ns |     7.49 ns |   2,410.8 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,755.6 ns |    54.08 ns |    50.59 ns |   2,779.0 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |   5,563.0 ns |    26.84 ns |    25.11 ns |   5,557.7 ns |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  13,493.7 ns |    37.21 ns |    32.98 ns |  13,507.9 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  17,874.0 ns |   355.25 ns |   364.82 ns |  18,068.4 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        |  79,589.9 ns |   461.84 ns |   432.01 ns |  79,647.1 ns |  131340 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 203,323.6 ns |   835.24 ns |   740.42 ns | 203,781.6 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 273,091.7 ns | 5,323.41 ns | 8,596.32 ns | 278,085.2 ns |         - |