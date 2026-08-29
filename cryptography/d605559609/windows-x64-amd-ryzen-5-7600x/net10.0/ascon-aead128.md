| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     355.9 ns |     1.87 ns |     1.66 ns |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     458.9 ns |     1.88 ns |     1.76 ns |      48 B |
|                                              |              |              |             |             |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128B         |     317.4 ns |     2.68 ns |     2.24 ns |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128B         |     380.6 ns |     2.42 ns |     2.14 ns |      88 B |
|                                              |              |              |             |             |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,643.2 ns |     6.40 ns |     5.35 ns |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,827.6 ns |    19.37 ns |    16.17 ns |      48 B |
|                                              |              |              |             |             |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 1KB          |   1,608.5 ns |    11.05 ns |     9.80 ns |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 1KB          |   1,727.3 ns |    27.91 ns |    24.74 ns |      88 B |
|                                              |              |              |             |             |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  12,036.1 ns |    95.48 ns |    79.73 ns |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  12,488.1 ns |    72.76 ns |    64.50 ns |      48 B |
|                                              |              |              |             |             |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 8KB          |  11,816.9 ns |    53.81 ns |    50.34 ns |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 8KB          |  12,451.4 ns |    89.30 ns |    83.53 ns |      88 B |
|                                              |              |              |             |             |           |
| Decrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 193,740.0 ns | 1,425.56 ns | 1,112.98 ns |         - |
| Decrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 198,142.6 ns |   904.26 ns |   845.84 ns |      48 B |
|                                              |              |              |             |             |           |
| Encrypt · Ascon-AEAD128 (CryptoHives-Scalar) | 128KB        | 187,410.6 ns | 1,234.25 ns | 1,154.52 ns |         - |
| Encrypt · Ascon-AEAD128 (BouncyCastle)       | 128KB        | 199,837.3 ns |   928.14 ns |   724.63 ns |      88 B |