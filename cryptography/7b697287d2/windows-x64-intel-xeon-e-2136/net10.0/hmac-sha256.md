| Description                                   | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     869.4 ns |     5.49 ns |     5.14 ns |   5,557 B |     320 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1,323.6 ns |    15.80 ns |    14.78 ns |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |   1,403.5 ns |    19.10 ns |    17.87 ns |   2,944 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     872.0 ns |    13.12 ns |    12.27 ns |   5,557 B |     336 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1,312.2 ns |    22.34 ns |    20.90 ns |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |   1,370.2 ns |     1.93 ns |     1.71 ns |   2,930 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |   2,798.1 ns |     6.65 ns |     6.22 ns |   5,568 B |    1216 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   4,115.3 ns |     6.01 ns |     5.02 ns |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   5,865.9 ns |    21.53 ns |    20.14 ns |   2,940 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |   2,791.5 ns |     5.51 ns |     4.88 ns |   5,568 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   4,114.6 ns |     5.87 ns |     4.90 ns |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   5,871.7 ns |    17.82 ns |    16.67 ns |   2,940 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |  17,744.3 ns |    27.93 ns |    23.32 ns |   5,579 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  26,427.3 ns |    27.14 ns |    24.05 ns |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  41,653.5 ns |    58.79 ns |    55.00 ns |   2,944 B |         - |
|                                               |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        | 324,121.1 ns |   291.98 ns |   243.82 ns |   5,579 B |  131278 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 408,669.3 ns |   554.25 ns |   491.33 ns |   1,552 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 673,590.3 ns | 1,487.42 ns | 1,391.34 ns |   2,930 B |         - |