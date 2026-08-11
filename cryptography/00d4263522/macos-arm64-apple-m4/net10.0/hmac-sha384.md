| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128B         |     868.7 ns |     3.35 ns |     3.14 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128B         |   1,014.5 ns |     2.87 ns |     2.68 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 128B         |   1,123.1 ns |     5.05 ns |     4.72 ns |     368 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 137B         |     858.1 ns |     6.48 ns |     6.06 ns |         - |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 137B         |   1,016.0 ns |     5.15 ns |     4.82 ns |         - |
| ComputeMac · HMAC-SHA384 · OS                 | 137B         |   1,098.5 ns |     5.34 ns |     5.00 ns |     384 B |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1KB          |   1,584.9 ns |     6.19 ns |     5.79 ns |    1264 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1KB          |   2,401.5 ns |     7.12 ns |     6.66 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1KB          |   2,766.6 ns |    28.75 ns |    26.89 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 1025B        |   1,583.7 ns |     7.02 ns |     6.57 ns |    1272 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 1025B        |   2,405.1 ns |     8.73 ns |     8.17 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 1025B        |   2,759.8 ns |    44.93 ns |    42.03 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 8KB          |   5,509.5 ns |    21.36 ns |    19.98 ns |    8432 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 8KB          |  13,499.7 ns |    35.92 ns |    31.84 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 8KB          |  18,007.2 ns |   218.69 ns |   193.86 ns |         - |
|                                               |              |              |             |             |           |
| ComputeMac · HMAC-SHA384 · OS                 | 128KB        |  78,385.0 ns |   415.46 ns |   388.62 ns |  131340 B |
| ComputeMac · HMAC-SHA384 · CryptoHives-Scalar | 128KB        | 203,888.3 ns |   649.93 ns |   507.42 ns |         - |
| ComputeMac · HMAC-SHA384 · BouncyCastle       | 128KB        | 277,789.7 ns | 5,468.57 ns | 6,078.30 ns |         - |