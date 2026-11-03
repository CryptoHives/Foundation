| Description                                  | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     437.6 ns |     1.90 ns |   1.78 ns |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     440.1 ns |     1.57 ns |   1.47 ns |      48 B |
|                                              |              |              |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     374.6 ns |     1.72 ns |   1.61 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     399.2 ns |     1.26 ns |   1.05 ns |         - |
|                                              |              |              |             |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,810.5 ns |     7.57 ns |   7.08 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,940.5 ns |    10.24 ns |   9.08 ns |         - |
|                                              |              |              |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,794.4 ns |     7.11 ns |   6.65 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,917.5 ns |     4.58 ns |   4.28 ns |         - |
|                                              |              |              |             |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  12,634.1 ns |    54.48 ns |  50.96 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,946.3 ns |    52.09 ns |  48.72 ns |         - |
|                                              |              |              |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  13,086.5 ns |    46.28 ns |  43.29 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  13,912.2 ns |    51.49 ns |  48.16 ns |         - |
|                                              |              |              |             |           |           |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 199,986.8 ns |   694.58 ns | 649.71 ns |      48 B |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 221,668.1 ns |   883.77 ns | 783.44 ns |         - |
|                                              |              |              |             |           |           |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 206,914.8 ns |   791.18 ns | 740.07 ns |      88 B |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 220,707.8 ns | 1,033.02 ns | 966.29 ns |         - |