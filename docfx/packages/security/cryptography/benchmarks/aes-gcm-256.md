| Description                               | TestDataSize | Mean          | Error         | StdDev        | Allocated |
|------------------------------------------ |------------- |--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 17B          |     109.20 ns |      0.785 ns |      0.734 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 17B          |     109.33 ns |      0.540 ns |      0.505 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 17B          |     127.12 ns |      1.781 ns |      1.666 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 17B          |     398.16 ns |      4.721 ns |      4.416 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 17B          |     687.32 ns |     13.140 ns |     12.291 ns |    1832 B |
|                                           |              |               |               |               |           |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 17B          |      75.34 ns |      0.393 ns |      0.368 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 17B          |      75.61 ns |      0.550 ns |      0.515 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 17B          |     133.45 ns |      1.353 ns |      1.265 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 17B          |     360.90 ns |      4.411 ns |      4.126 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 17B          |     619.63 ns |      5.666 ns |      5.300 ns |    1816 B |
|                                           |              |               |               |               |           |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 65B          |     110.17 ns |      0.292 ns |      0.259 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 65B          |     110.32 ns |      0.315 ns |      0.263 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 65B          |     127.69 ns |      0.885 ns |      0.739 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 65B          |     688.33 ns |      3.761 ns |      3.334 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 65B          |     889.16 ns |      6.323 ns |      5.915 ns |    1832 B |
|                                           |              |               |               |               |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 65B          |      84.53 ns |      0.690 ns |      0.612 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 65B          |      84.92 ns |      0.505 ns |      0.472 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 65B          |     139.67 ns |      1.757 ns |      1.643 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 65B          |     655.32 ns |      7.613 ns |      7.121 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 65B          |     841.93 ns |     14.392 ns |     14.135 ns |    1816 B |
|                                           |              |               |               |               |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 128B         |     109.37 ns |      0.451 ns |      0.399 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 128B         |     111.76 ns |      0.384 ns |      0.359 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 128B         |     125.14 ns |      0.454 ns |      0.402 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 128B         |     969.53 ns |      2.224 ns |      1.972 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 128B         |   1,091.54 ns |      9.700 ns |      9.073 ns |    1832 B |
|                                           |              |               |               |               |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 128B         |      70.38 ns |      0.425 ns |      0.377 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 128B         |      72.62 ns |      0.675 ns |      0.632 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 128B         |     126.54 ns |      1.179 ns |      1.102 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 128B         |     943.16 ns |      6.591 ns |      6.165 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 128B         |   1,015.95 ns |     16.972 ns |     15.875 ns |    1816 B |
|                                           |              |               |               |               |           |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 152B         |     131.50 ns |      0.505 ns |      0.448 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 152B         |     131.51 ns |      0.697 ns |      0.652 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 152B         |     144.22 ns |      0.958 ns |      0.896 ns |         - |
| Decrypt · AES-256-GCM (Managed)           | 152B         |   1,165.19 ns |      5.299 ns |      4.425 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 152B         |   1,269.20 ns |      6.332 ns |      5.613 ns |    1832 B |
|                                           |              |               |               |               |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 152B         |     100.14 ns |      0.551 ns |      0.515 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 152B         |     101.41 ns |      0.451 ns |      0.400 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 152B         |     146.51 ns |      2.013 ns |      1.883 ns |         - |
| Encrypt · AES-256-GCM (Managed)           | 152B         |   1,140.58 ns |     13.304 ns |     12.445 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 152B         |   1,168.46 ns |     13.830 ns |     12.260 ns |    1816 B |
|                                           |              |               |               |               |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 256B         |     118.59 ns |      0.355 ns |      0.332 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 256B         |     131.91 ns |      0.819 ns |      0.684 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 256B         |     137.22 ns |      0.640 ns |      0.598 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 256B         |   1,624.27 ns |      9.060 ns |      8.475 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 256B         |   1,730.42 ns |      3.820 ns |      3.190 ns |         - |
|                                           |              |               |               |               |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 256B         |      87.72 ns |      0.693 ns |      0.615 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 256B         |      91.39 ns |      0.616 ns |      0.577 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 256B         |     130.48 ns |      1.850 ns |      1.640 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 256B         |   1,561.23 ns |     17.880 ns |     16.725 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 256B         |   1,720.35 ns |     12.698 ns |     11.878 ns |         - |
|                                           |              |               |               |               |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 1KB          |     209.15 ns |      0.926 ns |      0.866 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 1KB          |     216.58 ns |      0.610 ns |      0.541 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 1KB          |     249.51 ns |      1.896 ns |      1.773 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 1KB          |   4,828.67 ns |     23.456 ns |     21.941 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 1KB          |   6,352.78 ns |     21.906 ns |     20.491 ns |         - |
|                                           |              |               |               |               |           |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 1KB          |     182.48 ns |      1.778 ns |      1.576 ns |         - |
| Encrypt · AES-256-GCM (OS)                | 1KB          |     186.82 ns |      1.783 ns |      1.489 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 1KB          |     192.56 ns |      0.971 ns |      0.908 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 1KB          |   4,783.83 ns |     83.917 ns |     78.496 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 1KB          |   6,410.86 ns |     83.153 ns |     77.782 ns |         - |
|                                           |              |               |               |               |           |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 8KB          |   1,096.38 ns |     21.775 ns |     24.203 ns |         - |
| Decrypt · AES-256-GCM (OS)                | 8KB          |   1,099.27 ns |     11.570 ns |     10.822 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 8KB          |   1,371.65 ns |     17.997 ns |     16.835 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 8KB          |  34,810.40 ns |    499.526 ns |    442.816 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 8KB          |  50,040.90 ns |    515.540 ns |    482.236 ns |         - |
|                                           |              |               |               |               |           |
| Encrypt · AES-256-GCM (OS)                | 8KB          |     747.46 ns |      6.398 ns |      5.985 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 8KB          |   1,130.17 ns |     13.413 ns |     11.201 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 8KB          |   1,224.25 ns |     16.769 ns |     15.686 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 8KB          |  34,494.75 ns |    279.354 ns |    247.640 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 8KB          |  49,893.15 ns |    484.561 ns |    453.259 ns |         - |
|                                           |              |               |               |               |           |
| Decrypt · AES-256-GCM (OS)                | 128KB        |  14,778.95 ns |     58.371 ns |     51.744 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMulV256) | 128KB        |  16,895.33 ns |    222.851 ns |    208.455 ns |         - |
| Decrypt · AES-256-GCM (AES-NI+PClMul)     | 128KB        |  21,077.03 ns |    295.995 ns |    262.392 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle)      | 128KB        | 549,252.63 ns |  6,475.250 ns |  6,056.952 ns |    1832 B |
| Decrypt · AES-256-GCM (Managed)           | 128KB        | 798,420.40 ns |  7,017.900 ns |  6,564.548 ns |         - |
|                                           |              |               |               |               |           |
| Encrypt · AES-256-GCM (OS)                | 128KB        |  11,054.44 ns |    104.249 ns |     97.515 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMulV256) | 128KB        |  17,522.23 ns |    212.456 ns |    177.411 ns |         - |
| Encrypt · AES-256-GCM (AES-NI+PClMul)     | 128KB        |  18,685.08 ns |    278.714 ns |    260.709 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle)      | 128KB        | 549,206.39 ns |  9,746.122 ns | 10,428.241 ns |    1816 B |
| Encrypt · AES-256-GCM (Managed)           | 128KB        | 800,201.00 ns | 10,435.799 ns |  9,251.064 ns |         - |