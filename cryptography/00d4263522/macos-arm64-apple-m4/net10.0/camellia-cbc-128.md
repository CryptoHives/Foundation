| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     610.7 ns |     7.67 ns |     7.18 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     905.3 ns |    10.02 ns |     9.37 ns |     576 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     687.2 ns |     7.68 ns |     7.18 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     906.2 ns |    10.93 ns |    10.22 ns |     576 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,248.5 ns |     6.92 ns |     5.40 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,905.2 ns |    82.78 ns |    77.44 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,960.1 ns |     7.48 ns |     5.84 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,986.6 ns |    77.80 ns |    72.77 ns |    2816 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,554.6 ns |    66.20 ns |    51.69 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  45,704.3 ns |   598.95 ns |   560.26 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  39,126.1 ns |    24.18 ns |    18.88 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  46,282.7 ns |   633.83 ns |   592.88 ns |   20736 B |
|                                                 |              |              |             |             |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 539,402.2 ns |   670.47 ns |   523.46 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 728,205.8 ns | 9,846.64 ns | 9,210.55 ns |  327936 B |
|                                                 |              |              |             |             |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 629,471.4 ns | 7,270.97 ns | 6,801.27 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 730,377.9 ns | 8,946.01 ns | 7,930.41 ns |  327936 B |