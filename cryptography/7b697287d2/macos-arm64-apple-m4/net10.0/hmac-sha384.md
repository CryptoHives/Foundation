| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     880.5 ns |    17.48 ns |    18.70 ns |     888.3 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |     938.9 ns |     1.92 ns |     1.50 ns |     938.7 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1,078.9 ns |     0.90 ns |     0.84 ns |   1,078.8 ns |     368 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     892.0 ns |     9.76 ns |     9.13 ns |     893.9 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |     939.5 ns |     4.74 ns |     3.70 ns |     938.4 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1,059.3 ns |     1.72 ns |     1.52 ns |   1,059.1 ns |     384 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,557.8 ns |     1.46 ns |     1.22 ns |   1,558.0 ns |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,202.4 ns |    10.63 ns |     8.88 ns |   2,203.8 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,824.1 ns |    55.99 ns |    64.48 ns |   2,854.2 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,557.9 ns |     1.14 ns |     1.06 ns |   1,557.8 ns |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,323.0 ns |    46.14 ns |   118.27 ns |   2,302.8 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,869.9 ns |     7.76 ns |     7.26 ns |   2,871.2 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |   5,453.3 ns |     2.13 ns |     1.89 ns |   5,453.8 ns |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  12,697.2 ns |   230.79 ns |   455.56 ns |  12,390.3 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  18,305.2 ns |   365.91 ns |   524.78 ns |  18,532.2 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        |  77,418.5 ns |   109.48 ns |    97.05 ns |  77,424.3 ns |  131340 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 186,727.2 ns | 2,676.73 ns | 2,089.82 ns | 186,115.3 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 256,540.6 ns | 5,124.56 ns | 5,695.94 ns | 256,060.3 ns |         - |