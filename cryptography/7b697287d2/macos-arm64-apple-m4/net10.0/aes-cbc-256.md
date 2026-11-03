| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      25.74 ns |     0.016 ns |     0.013 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 128B         |     224.38 ns |     1.076 ns |     1.007 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     472.93 ns |     0.612 ns |     0.511 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128B         |     788.38 ns |     0.920 ns |     0.815 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128B         |      47.11 ns |     0.141 ns |     0.132 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128B         |     247.44 ns |     1.269 ns |     1.187 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128B         |     558.00 ns |     0.381 ns |     0.318 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128B         |     723.04 ns |     1.084 ns |     0.961 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     108.16 ns |     0.293 ns |     0.260 ns |         - |
| Decrypt · AES-256-CBC (OS)                  | 1KB          |     278.19 ns |     1.448 ns |     1.283 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   3,294.62 ns |     3.682 ns |     3.444 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,389.06 ns |    15.495 ns |    13.736 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 1KB          |     461.75 ns |     0.203 ns |     0.158 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 1KB          |     721.21 ns |     3.715 ns |     3.475 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 1KB          |   4,009.66 ns |     1.577 ns |     1.398 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 1KB          |   4,258.00 ns |     1.363 ns |     1.138 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 8KB          |     733.04 ns |     4.795 ns |     4.486 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |     756.94 ns |     3.087 ns |     2.888 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  26,054.16 ns |    15.388 ns |    12.850 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  33,140.00 ns |    99.735 ns |    93.293 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 8KB          |   4,072.88 ns |     1.770 ns |     1.478 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 8KB          |   4,421.52 ns |     2.997 ns |     2.502 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 8KB          |  31,564.57 ns |    13.056 ns |    10.902 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 8KB          |  32,607.14 ns |    38.406 ns |    32.070 ns |    1024 B |
|                                             |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)                  | 128KB        |   8,635.29 ns |    43.524 ns |    40.712 ns |      72 B |
| Decrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  11,970.54 ns |    94.345 ns |    78.783 ns |         - |
| Decrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 416,803.73 ns |   189.287 ns |   147.783 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 526,843.00 ns | 2,390.939 ns | 2,236.486 ns |    1024 B |
|                                             |              |               |              |              |           |
| Encrypt · AES-256-CBC (CryptoHives-ARM-AES) | 128KB        |  65,971.46 ns |    28.082 ns |    21.925 ns |         - |
| Encrypt · AES-256-CBC (OS)                  | 128KB        |  68,990.74 ns |    42.431 ns |    35.431 ns |      72 B |
| Encrypt · AES-256-CBC (CryptoHives-Scalar)  | 128KB        | 504,428.43 ns |   210.312 ns |   175.620 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle)        | 128KB        | 519,984.40 ns |   264.755 ns |   221.083 ns |    1024 B |