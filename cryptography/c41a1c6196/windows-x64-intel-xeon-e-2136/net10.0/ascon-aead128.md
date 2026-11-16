| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     744.9 ns |     2.10 ns |     1.97 ns |     310 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     842.5 ns |     1.30 ns |     1.15 ns |     310 B |      48 B |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     648.3 ns |     2.37 ns |     2.22 ns |     390 B |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     735.5 ns |     1.39 ns |     1.23 ns |     387 B |      88 B |
|                                              |              |              |             |             |           |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   3,542.8 ns |    14.15 ns |    13.24 ns |     310 B |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   3,571.4 ns |     3.73 ns |     3.11 ns |     310 B |      48 B |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   3,460.4 ns |     3.47 ns |     3.24 ns |     387 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   3,462.3 ns |    11.17 ns |    10.45 ns |     390 B |         - |
|                                              |              |              |             |             |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  24,944.4 ns |    19.39 ns |    18.13 ns |     310 B |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  25,484.9 ns |   123.88 ns |   115.88 ns |     310 B |         - |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  25,052.3 ns |    24.00 ns |    22.45 ns |     387 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  25,473.1 ns |   142.53 ns |   126.35 ns |     387 B |         - |
|                                              |              |              |             |             |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 395,712.8 ns | 1,085.39 ns | 1,015.28 ns |     310 B |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 404,017.6 ns | 1,672.97 ns | 1,564.90 ns |     310 B |         - |
|                                              |              |              |             |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 391,737.6 ns |   834.42 ns |   780.52 ns |     387 B |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 408,120.3 ns | 1,501.55 ns | 1,404.55 ns |     387 B |         - |