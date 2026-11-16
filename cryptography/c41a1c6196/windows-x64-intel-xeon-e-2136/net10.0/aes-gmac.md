| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |     105.1 ns |   0.12 ns |   0.11 ns |  13,267 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |   1,041.4 ns |   3.95 ns |   3.30 ns |  21,263 B |    1816 B |
|                                            |              |              |           |           |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |     110.9 ns |   0.03 ns |   0.02 ns |  13,276 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |   1,089.5 ns |  15.57 ns |  14.56 ns |  21,843 B |    1816 B |
|                                            |              |              |           |           |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     232.7 ns |   0.11 ns |   0.09 ns |  13,267 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,720.5 ns |  12.02 ns |  11.24 ns |  21,255 B |    1816 B |
|                                            |              |              |           |           |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     242.1 ns |   0.18 ns |   0.15 ns |  13,273 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,739.6 ns |   3.83 ns |   3.59 ns |  21,528 B |    1816 B |
|                                            |              |              |           |           |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   1,280.3 ns |   2.21 ns |   2.07 ns |  13,267 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  15,657.0 ns |  28.70 ns |  26.85 ns |  21,003 B |    1816 B |
|                                            |              |              |           |           |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  20,283.6 ns | 389.20 ns | 364.06 ns |  13,516 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 241,349.8 ns | 443.76 ns | 415.10 ns |  21,204 B |    1816 B |