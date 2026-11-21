| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| ComputeMac · HMAC-SHA1 · OS                 | 128B         |     846.5 ns |     0.77 ns |     0.72 ns |  12,821 B |     296 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128B         |   1,480.9 ns |     0.83 ns |     0.69 ns |   9,745 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128B         |   1,922.5 ns |    12.28 ns |    10.26 ns |   1,127 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 137B         |     846.4 ns |     0.46 ns |     0.41 ns |  12,631 B |     312 B |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 137B         |   1,419.3 ns |     5.87 ns |     5.21 ns |   9,943 B |         - |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 137B         |   1,919.6 ns |    17.90 ns |    15.87 ns |   1,127 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1KB          |   2,598.9 ns |     2.05 ns |     1.92 ns |  12,817 B |    1192 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1KB          |   5,798.9 ns |    38.69 ns |    36.19 ns |   1,127 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1KB          |   6,340.4 ns |     3.23 ns |     2.70 ns |   9,753 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 1025B        |   2,600.5 ns |     1.65 ns |     1.54 ns |  12,821 B |    1200 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 1025B        |   5,794.8 ns |    34.64 ns |    28.93 ns |   1,127 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 1025B        |   6,029.1 ns |    30.91 ns |    27.40 ns |   9,943 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 8KB          |  16,114.9 ns |    25.81 ns |    22.88 ns |  12,687 B |    8360 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 8KB          |  36,919.8 ns |   470.02 ns |   439.65 ns |   1,127 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 8KB          |  45,658.0 ns |   634.96 ns |   593.94 ns |   5,902 B |         - |
|                                             |              |              |             |             |           |           |
| ComputeMac · HMAC-SHA1 · OS                 | 128KB        | 319,001.8 ns |   271.29 ns |   240.49 ns |   8,827 B |  131294 B |
| ComputeMac · HMAC-SHA1 · CryptoHives-Scalar | 128KB        | 562,181.1 ns |   642.10 ns |   501.31 ns |   1,127 B |         - |
| ComputeMac · HMAC-SHA1 · BouncyCastle       | 128KB        | 724,022.7 ns | 7,133.98 ns | 6,673.13 ns |   9,935 B |         - |