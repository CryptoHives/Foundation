| Description                                   | TestDataSize | Mean         | Error       | StdDev       | Allocated |
|---------------------------------------------- |------------- |-------------:|------------:|-------------:|----------:|
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |     371.9 ns |     1.01 ns |      0.95 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |     582.1 ns |     5.01 ns |      4.69 ns |     320 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |     847.2 ns |    16.51 ns |     18.35 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |     373.8 ns |     2.08 ns |      1.73 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |     572.3 ns |     3.79 ns |      3.55 ns |     336 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |     842.4 ns |    16.39 ns |     26.93 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |     647.5 ns |     4.59 ns |      4.07 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |     868.3 ns |     1.64 ns |      1.45 ns |    1216 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   3,727.3 ns |    73.75 ns |    142.09 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |     658.1 ns |     9.78 ns |      9.15 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |     867.9 ns |     2.23 ns |      1.97 ns |    1224 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   3,730.7 ns |    73.98 ns |    125.62 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |   3,052.1 ns |    11.41 ns |     10.12 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |   3,191.7 ns |     6.77 ns |      6.34 ns |    8384 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  26,355.3 ns |   526.81 ns |  1,134.01 ns |         - |
|                                               |              |              |             |              |           |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        |  44,206.6 ns |    57.02 ns |     53.34 ns |         - |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        |  48,503.7 ns |   218.23 ns |    204.13 ns |  131292 B |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 419,451.7 ns | 8,358.62 ns | 17,447.56 ns |         - |