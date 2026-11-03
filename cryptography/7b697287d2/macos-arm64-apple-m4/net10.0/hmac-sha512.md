| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     887.1 ns |    17.20 ns |    16.89 ns |     895.3 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |     940.4 ns |     4.79 ns |     4.00 ns |     940.8 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |   1,057.9 ns |     1.59 ns |     1.41 ns |   1,057.5 ns |     416 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     896.1 ns |     8.31 ns |     7.77 ns |     899.9 ns |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |     942.9 ns |     6.91 ns |     5.39 ns |     941.9 ns |         - |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |   1,037.1 ns |     0.74 ns |     0.69 ns |   1,037.4 ns |     432 B |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,535.1 ns |     1.04 ns |     0.97 ns |   1,535.3 ns |    1312 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,210.3 ns |    10.11 ns |     7.90 ns |   2,210.0 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,817.7 ns |    55.85 ns |    64.32 ns |   2,847.0 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,537.2 ns |     0.68 ns |     0.63 ns |   1,537.0 ns |    1320 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,318.6 ns |    46.32 ns |   127.58 ns |   2,254.3 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,504.4 ns |    45.96 ns |    43.00 ns |   2,496.5 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |   5,423.9 ns |     1.69 ns |     1.58 ns |   5,423.5 ns |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  12,877.9 ns |   255.02 ns |   575.62 ns |  12,620.5 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  18,367.4 ns |   358.03 ns |   477.96 ns |  18,526.3 ns |         - |
|                                               |              |              |             |             |              |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        |  77,536.4 ns |   113.26 ns |   105.95 ns |  77,531.5 ns |  131388 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 185,881.1 ns |   503.62 ns |   446.44 ns | 185,938.4 ns |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 283,934.0 ns | 5,594.47 ns | 9,798.27 ns | 287,942.0 ns |         - |