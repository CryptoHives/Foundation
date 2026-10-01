| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     882.1 ns |     9.71 ns |     9.08 ns |     884.6 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |     998.1 ns |     6.02 ns |     5.03 ns |     997.0 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1,059.6 ns |     1.42 ns |     1.26 ns |   1,059.6 ns |     416 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     882.4 ns |     6.52 ns |     6.10 ns |     883.1 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |     998.8 ns |     7.91 ns |     6.18 ns |     998.3 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1,037.5 ns |     1.08 ns |     1.01 ns |   1,037.3 ns |     432 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,537.6 ns |     0.76 ns |     0.67 ns |   1,537.7 ns |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,372.4 ns |    29.47 ns |    40.34 ns |   2,361.9 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,780.1 ns |    55.28 ns |    61.44 ns |   2,812.7 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,536.8 ns |     0.67 ns |     0.59 ns |   1,536.8 ns |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,357.0 ns |    13.49 ns |    11.26 ns |   2,353.0 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,786.1 ns |    54.77 ns |    83.64 ns |   2,832.4 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |   5,419.3 ns |     1.52 ns |     1.34 ns |   5,419.7 ns |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  13,235.1 ns |    72.93 ns |    60.90 ns |  13,249.0 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  18,013.8 ns |   349.78 ns |   442.35 ns |  18,054.4 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        |  77,485.3 ns |    71.37 ns |    66.76 ns |  77,467.7 ns |  131388 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 199,401.8 ns | 1,346.10 ns | 1,124.05 ns | 199,256.7 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 280,918.2 ns | 5,603.08 ns | 7,086.11 ns | 284,927.3 ns |         - |