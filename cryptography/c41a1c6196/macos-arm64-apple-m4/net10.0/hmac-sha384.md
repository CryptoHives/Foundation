| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     900.5 ns |     6.27 ns |     5.87 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |     949.3 ns |     4.18 ns |     3.26 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1,097.1 ns |     2.32 ns |     2.17 ns |     368 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     904.1 ns |     3.95 ns |     3.50 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |     953.0 ns |     4.36 ns |     3.64 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1,074.8 ns |     5.57 ns |     5.21 ns |     384 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,575.0 ns |     1.52 ns |     1.42 ns |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,237.1 ns |    11.31 ns |     9.44 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,869.9 ns |    54.93 ns |    51.38 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,577.3 ns |     3.49 ns |     3.26 ns |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,242.5 ns |    15.80 ns |    13.20 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,885.8 ns |    45.20 ns |    42.28 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |   5,505.4 ns |    10.30 ns |     9.63 ns |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  12,953.4 ns |   258.48 ns |   378.87 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  18,806.6 ns |   358.00 ns |   334.87 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        |  78,086.2 ns |   129.54 ns |   121.17 ns |  131340 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 189,056.4 ns |   859.67 ns |   762.08 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 290,885.0 ns | 5,662.17 ns | 7,558.84 ns |         - |