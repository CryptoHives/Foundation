| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA512 · OS                 | 128B         |     622.5 ns |   1.63 ns |   1.36 ns |   4,626 B |     416 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128B         |     786.9 ns |   1.81 ns |   1.61 ns |   2,888 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128B         |   1,081.9 ns |   2.33 ns |   2.07 ns |   1,443 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 137B         |     628.8 ns |   2.05 ns |   1.71 ns |   4,626 B |     432 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 137B         |     775.8 ns |   2.11 ns |   1.87 ns |   2,905 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 137B         |   1,088.4 ns |   1.70 ns |   1.42 ns |   1,443 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1KB          |   1,750.5 ns |   7.53 ns |   6.29 ns |   4,624 B |    1312 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1KB          |   2,448.0 ns |   6.24 ns |   5.53 ns |   2,911 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1KB          |   2,528.2 ns |  11.51 ns |   9.61 ns |   1,443 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 1025B        |   1,747.3 ns |   6.22 ns |   5.82 ns |   4,646 B |    1320 B |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 1025B        |   2,454.3 ns |   7.93 ns |   7.03 ns |   2,888 B |         - |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 1025B        |   2,521.9 ns |   4.33 ns |   3.38 ns |   1,443 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 8KB          |  10,703.9 ns |  43.20 ns |  38.29 ns |   4,576 B |    8480 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 8KB          |  13,986.0 ns |  24.17 ns |  21.43 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 8KB          |  15,831.2 ns |  43.94 ns |  36.69 ns |   2,911 B |         - |
|                                               |              |              |           |           |           |           |
| ComputeMac · HMAC-SHA512 · OS                 | 128KB        | 192,060.2 ns | 771.05 ns | 683.52 ns |   4,576 B |  131374 B |
| ComputeMac · HMAC-SHA512 · CryptoHives-Scalar | 128KB        | 211,923.8 ns | 671.47 ns | 595.24 ns |   1,443 B |         - |
| ComputeMac · HMAC-SHA512 · BouncyCastle       | 128KB        | 245,008.4 ns | 600.15 ns | 532.02 ns |   2,905 B |         - |